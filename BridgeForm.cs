using Advanced_Combat_Tracker;
using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplitBridge {
  public partial class BridgeForm:UserControl, IActPluginV1 {
    private Label pluginLabel;
    private string settingsFile;
    private SettingsSerializer xmlSettings;
    private NamedPipeClientStream client;
    private StreamWriter clientWriter;
    private readonly string SENDKEYS_HELP_LINK = "https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys.send?view=netframework-4.8#remarks";
    public delegate void CustomCallbackDelegate(object o, string param);

    public BridgeForm() {
      InitializeComponent();
      InitTrigg();
    }

    #region IActPluginV1 Members
    public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText) {
      // ACT Stuff
      pluginLabel = pluginStatusText;
      pluginScreenSpace.Controls.Add(this);
      pluginScreenSpace.Text = "LiveSplit Bridge";
      Dock = DockStyle.Fill;

      // Settings
      string configName = "LiveSplitBridge";
      try {
        string pluginName = ActGlobals.oFormActMain.PluginGetSelfData(this).pluginFile.FullName;
        pluginName = Path.GetFileNameWithoutExtension(pluginName).Trim();
        if (pluginName.Length >= 0)
          configName = pluginName;
      } catch (Exception) { }
      settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, $"Config\\{configName}.config.xml");
      xmlSettings = new SettingsSerializer(this);
      LoadSettings();

      // Finish and update status
      pluginLabel.Text = "Plugin Started";
      Log($"Plugin loaded.");
    }

    public void DeInitPlugin() {
      SaveSettings();
      pluginLabel.Text = "Plugin Exited";
    }
    #endregion

    #region LiveSplit Functions
    public void WriteToPipe(string text) {
      try {
        if (text != "reset" || resetModeCmb.Text == "Server") {
          clientWriter.WriteLine(text);
          Log($"Wrote to pipe: {text}");
        } else {
          SendKeys.Send(resetHotkeyTxt.Text);
          Log($"Reset hotkey fired: {resetHotkeyTxt.Text}");
        }
      } catch (Exception ex) {
        Log($"[Error][{text}] {ex}");
      }
    }

    private void Connect() {
      try {
        connectBtn.Enabled = false;
        Log($"Connecting...");

        client = new NamedPipeClientStream(".", "LiveSplit", PipeDirection.Out, PipeOptions.Asynchronous);
        client.Connect(3000);
        clientWriter = new StreamWriter(client);
        clientWriter.AutoFlush = true;

        disconnectBtn.Enabled = true;
        testSplitBtn.Enabled = true;
        testResetBtn.Enabled = true;

        Log($"Connected to LiveSplit named pipe.");
      } catch (TimeoutException) {
        connectBtn.Enabled = true;
        Log($"Connection timed out. Please make sure LiveSplit is open.");
      } catch (Exception ex) {
        connectBtn.Enabled = true;
        Log($"[Error Connecting] {ex}");
      }
    }

    private void Disconnect() {
      try {
        disconnectBtn.Enabled = false;
        Log($"Disconnecting...");

        clientWriter.Dispose();
        client.Dispose();

        connectBtn.Enabled = true;
        disconnectBtn.Enabled = false;
        testSplitBtn.Enabled = false;
        testResetBtn.Enabled = false;

        Log($"Disconnected.");
      } catch (Exception ex) {
        disconnectBtn.Enabled = true;
        Log($"[Error Disconnecting] {ex}");
      }
    }
    #endregion

    #region Triggernometry Integration
    private void InitTrigg() {
      try {
        var trigg = ActGlobals.oFormActMain.ActPlugins.FirstOrDefault(x => x.lblPluginTitle.Text == "Triggernometry.dll");
        if (trigg == null || trigg.pluginObj == null)
          return;

        var triggType = trigg.pluginObj.GetType();
        var deleType = triggType.GetNestedType("CustomCallbackDelegate");
        if (deleType == null)
          return;

        var dele = Delegate.CreateDelegate(deleType, this, typeof(BridgeForm).GetMethod("HandleTriggMessage"));
        triggType.GetMethod("RegisterNamedCallback")?.Invoke(trigg.pluginObj, new object[] { "LiveSplitMessage", dele, null });
        Log($"Registered Triggernometry callback \"LiveSplitMessage\".");
      } catch (Exception ex) {
        Log($"Failed to register Triggernometry callback: {ex}");
      }
    }

    public void HandleTriggMessage(object _, string msg) {
      Log($"Received message from Trigg: {msg}");
      if (client != null && client.IsConnected)
        WriteToPipe(msg);
    }
    #endregion

    #region UI Events
    private void resetDefaultBtn_Click(object sender, EventArgs e) {
      resetModeCmb.SelectedIndex = 0;
      resetHotkeyTxt.Text = "{F15}";
    }

    private void logList_KeyUp(object sender, KeyEventArgs e) {
      if (sender != logList)
        return;

      if (e.Control && e.KeyCode == Keys.C && logList.SelectedItems.Count > 0) {
        var builder = new StringBuilder();
        foreach (ListViewItem item in logList.SelectedItems)
          builder.AppendLine($"[{item.SubItems[0].Text}] {item.SubItems[1].Text}");

        string clipboard = builder.ToString().Trim();
        if (clipboard.Length > 0) {
          Clipboard.SetText(clipboard);
          System.Media.SystemSounds.Asterisk.Play();
        }
      }
    }
    private void copyLogBtn_Click(object sender, EventArgs e) {
      var builder = new StringBuilder();
      foreach (ListViewItem item in logList.Items)
        builder.AppendLine($"[{item.SubItems[0].Text}] {item.SubItems[1].Text}");

      string clipboard = builder.ToString().Trim();
      if (clipboard.Length > 0) {
        Clipboard.SetText(clipboard);
        System.Media.SystemSounds.Asterisk.Play();
      }
    }

    private void clearLogBtn_Click(object sender, EventArgs e) {
      logList.Items.Clear();
    }

    private void testSplitBtn_Click(object sender, EventArgs e) {
      WriteToPipe("startorsplit");
    }

    private void testResetBtn_Click(object sender, EventArgs e) {
      WriteToPipe("reset");
    }

    private void resetHotkeyLbl_Click(object sender, EventArgs e) {
      System.Diagnostics.Process.Start(SENDKEYS_HELP_LINK);
    }

    private async void connectBtn_Click(object sender, EventArgs e) {
      await Task.Run(Connect);
    }

    private async void disconnectBtn_Click(object sender, EventArgs e) {
      await Task.Run(Disconnect);
    }
    #endregion

    #region Settings
    public void Log(string text) {
      string[] row = new string[2];
      row[0] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
      row[1] = text;
      logList.Items.Add(new ListViewItem(row));
      logList.Items[logList.Items.Count - 1].EnsureVisible();
      logList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

    public void LoadSettings() {
      xmlSettings.AddControlSetting(resetHotkeyTxt.Name, resetHotkeyTxt);
      xmlSettings.AddControlSetting(resetModeCmb.Name, resetModeCmb);
      if (File.Exists(settingsFile)) {
        FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        XmlTextReader xReader = new XmlTextReader(fs);
        try {
          while (xReader.Read())
            if (xReader.NodeType == XmlNodeType.Element)
              if (xReader.LocalName == "SettingsSerializer")
                xmlSettings.ImportFromXml(xReader);
        } catch (Exception ex) {
          pluginLabel.Text = "Error loading settings: " + ex.Message;
        }
        xReader.Close();
      }
      resetModeCmb.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    public bool SaveSettings() {
      try {
        FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
        xWriter.Formatting = Formatting.Indented;
        xWriter.Indentation = 1;
        xWriter.IndentChar = '\t';
        xWriter.WriteStartDocument(true);
        xWriter.WriteStartElement("Config");
        xWriter.WriteStartElement("SettingsSerializer");
        xmlSettings.ExportToXml(xWriter);
        xWriter.WriteEndElement();
        xWriter.WriteEndElement();
        xWriter.WriteEndDocument();
        xWriter.Flush();
        xWriter.Close();
      } catch {
        return false;
      }
      return true;
    }
    #endregion
  }
}
