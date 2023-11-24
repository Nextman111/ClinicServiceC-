namespace ClinicDesctop
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxLists = new GroupBox();
            buttonLoadLists = new Button();
            radioButtonPets = new RadioButton();
            radioButtonClients = new RadioButton();
            groupBoxAction = new GroupBox();
            buttonRemove = new Button();
            buttonAdd = new Button();
            buttonEdit = new Button();
            groupBoxView = new GroupBox();
            listViewPreview = new ListView();
            groupBoxLists.SuspendLayout();
            groupBoxAction.SuspendLayout();
            groupBoxView.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxLists
            // 
            groupBoxLists.Controls.Add(buttonLoadLists);
            groupBoxLists.Controls.Add(radioButtonPets);
            groupBoxLists.Controls.Add(radioButtonClients);
            groupBoxLists.Location = new Point(9, 0);
            groupBoxLists.Name = "groupBoxLists";
            groupBoxLists.Padding = new Padding(10, 3, 10, 3);
            groupBoxLists.Size = new Size(167, 118);
            groupBoxLists.TabIndex = 2;
            groupBoxLists.TabStop = false;
            groupBoxLists.Text = "Списки";
            // 
            // buttonLoadLists
            // 
            buttonLoadLists.Dock = DockStyle.Top;
            buttonLoadLists.Location = new Point(10, 71);
            buttonLoadLists.Name = "buttonLoadLists";
            buttonLoadLists.Size = new Size(147, 29);
            buttonLoadLists.TabIndex = 5;
            buttonLoadLists.Text = "Загрузить";
            buttonLoadLists.UseVisualStyleBackColor = true;
            buttonLoadLists.Click += buttonLoadLists_Click;
            // 
            // radioButtonPets
            // 
            radioButtonPets.AutoSize = true;
            radioButtonPets.Dock = DockStyle.Top;
            radioButtonPets.Location = new Point(10, 47);
            radioButtonPets.Name = "radioButtonPets";
            radioButtonPets.Size = new Size(147, 24);
            radioButtonPets.TabIndex = 5;
            radioButtonPets.TabStop = true;
            radioButtonPets.Text = "Питомцы";
            radioButtonPets.UseVisualStyleBackColor = true;
            // 
            // radioButtonClients
            // 
            radioButtonClients.AutoSize = true;
            radioButtonClients.Dock = DockStyle.Top;
            radioButtonClients.Location = new Point(10, 23);
            radioButtonClients.Name = "radioButtonClients";
            radioButtonClients.Size = new Size(147, 24);
            radioButtonClients.TabIndex = 4;
            radioButtonClients.TabStop = true;
            radioButtonClients.Text = "Клиенты";
            radioButtonClients.UseVisualStyleBackColor = true;
            // 
            // groupBoxAction
            // 
            groupBoxAction.Controls.Add(buttonRemove);
            groupBoxAction.Controls.Add(buttonAdd);
            groupBoxAction.Controls.Add(buttonEdit);
            groupBoxAction.Location = new Point(9, 124);
            groupBoxAction.Name = "groupBoxAction";
            groupBoxAction.Padding = new Padding(10, 3, 10, 3);
            groupBoxAction.Size = new Size(167, 182);
            groupBoxAction.TabIndex = 3;
            groupBoxAction.TabStop = false;
            groupBoxAction.Text = "Действия";
            // 
            // buttonRemove
            // 
            buttonRemove.Dock = DockStyle.Top;
            buttonRemove.Location = new Point(10, 117);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(147, 47);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Dock = DockStyle.Top;
            buttonAdd.Location = new Point(10, 70);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(147, 47);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            buttonEdit.Dock = DockStyle.Top;
            buttonEdit.Location = new Point(10, 23);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(147, 47);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // groupBoxView
            // 
            groupBoxView.Controls.Add(listViewPreview);
            groupBoxView.Dock = DockStyle.Right;
            groupBoxView.Location = new Point(185, 0);
            groupBoxView.Name = "groupBoxView";
            groupBoxView.Size = new Size(993, 594);
            groupBoxView.TabIndex = 4;
            groupBoxView.TabStop = false;
            groupBoxView.Text = "Просмотр";
            // 
            // listViewPreview
            // 
            listViewPreview.Dock = DockStyle.Fill;
            listViewPreview.GridLines = true;
            listViewPreview.Location = new Point(3, 23);
            listViewPreview.Name = "listViewPreview";
            listViewPreview.Size = new Size(987, 568);
            listViewPreview.TabIndex = 0;
            listViewPreview.UseCompatibleStateImageBehavior = false;
            listViewPreview.View = View.Details;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 594);
            Controls.Add(groupBoxView);
            Controls.Add(groupBoxAction);
            Controls.Add(groupBoxLists);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Клиент ClinicDesctop";
            groupBoxLists.ResumeLayout(false);
            groupBoxLists.PerformLayout();
            groupBoxAction.ResumeLayout(false);
            groupBoxView.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonClients;
        private Button buttonPets;
        private GroupBox groupBoxLists;
        private GroupBox groupBoxAction;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonRemove;
        private RadioButton radioButtonClients;
        private RadioButton radioButtonPets;
        private GroupBox groupBoxView;
        private Button buttonLoadLists;
        private ListView listViewPreview;
    }
}
