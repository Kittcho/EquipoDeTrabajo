using System;
using System.ComponentModel;

namespace Samples
{
  /// <summary>
  /// Summary description for BaseDemoControl.
  /// </summary>
  public class BaseDemoControl : System.Windows.Forms.UserControl
  {
    protected string writeStatus1 = "";
    protected string writeStatus2 = "";
    private System.ComponentModel.Container components = null;

    public BaseDemoControl() {

      InitializeComponent();
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing ) {
      if( disposing ) {
        if(components != null) {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    protected void OnWriteStatus() {

      if (WriteStatus != null)
        WriteStatus(this);
    }

    #region Component Designer generated code
    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      // 
      // BaseDemoControl
      // 
      this.Name = "BaseDemoControl";

    }
    #endregion

    public event WriteStatusHandler WriteStatus;

    [Browsable(false)]
    public string WriteStatus1 {
      get {
        return writeStatus1;
      }
    }

    [Browsable(false)]
    public string WriteStatus2 {
      get {
        return writeStatus2;
      }
    }
  }

  public delegate void WriteStatusHandler(BaseDemoControl control);
}
