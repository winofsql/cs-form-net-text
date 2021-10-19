using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace cs_form_net_text {

    public partial class Form1 : Form {

        public Form1()
        {
            InitializeComponent();
        }

        private void read_button_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            try
            {
                // インターネットアクセス用クラス( WebClient )
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.GetEncoding("shift_jis");

                Uri uri = new Uri("https://lightbox.sakura.ne.jp/demo/json/syain_csv.php");

                string result = webClient.DownloadString(uri);

                this.textarea.Text = result;

                Debug.WriteLine(result);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        private void write_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "syain.csv";
            sfd.Filter = "CSVファイル|*.csv|すべてのファイル|*.*";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WebClient webClient = new WebClient();
                try
                {
                    webClient.DownloadFile("https://lightbox.sakura.ne.jp/demo/json/syain_csv.php", sfd.FileName);
                    MessageBox.Show(this, "ダウンロードが完了しました");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show(this, "ダウンロードが失敗しました");
                }

            }

        }
    }
}
