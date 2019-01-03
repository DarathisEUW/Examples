namespace SortingHat
{
    partial class Sort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPopulateArray = new System.Windows.Forms.Button();
            this.buttonResetCurrentArray = new System.Windows.Forms.Button();
            this.buttonBubbleSort = new System.Windows.Forms.Button();
            this.buttonInsertionSort = new System.Windows.Forms.Button();
            this.buttonSelectionSort = new System.Windows.Forms.Button();
            this.sortBubbleTime = new System.Windows.Forms.Label();
            this.sortInsertTime = new System.Windows.Forms.Label();
            this.sortSelectionTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(390, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sorting Hat";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonPopulateArray
            // 
            this.buttonPopulateArray.Location = new System.Drawing.Point(377, 158);
            this.buttonPopulateArray.Name = "buttonPopulateArray";
            this.buttonPopulateArray.Size = new System.Drawing.Size(100, 48);
            this.buttonPopulateArray.TabIndex = 1;
            this.buttonPopulateArray.Text = "Populate";
            this.buttonPopulateArray.UseVisualStyleBackColor = true;
            this.buttonPopulateArray.Click += new System.EventHandler(this.buttonPopulateArray_Click);
            // 
            // buttonResetCurrentArray
            // 
            this.buttonResetCurrentArray.Location = new System.Drawing.Point(483, 158);
            this.buttonResetCurrentArray.Name = "buttonResetCurrentArray";
            this.buttonResetCurrentArray.Size = new System.Drawing.Size(95, 48);
            this.buttonResetCurrentArray.TabIndex = 2;
            this.buttonResetCurrentArray.Text = "Reset";
            this.buttonResetCurrentArray.UseVisualStyleBackColor = true;
            this.buttonResetCurrentArray.Click += new System.EventHandler(this.buttonResetCurrentArray_Click);
            // 
            // buttonBubbleSort
            // 
            this.buttonBubbleSort.Location = new System.Drawing.Point(232, 355);
            this.buttonBubbleSort.Name = "buttonBubbleSort";
            this.buttonBubbleSort.Size = new System.Drawing.Size(95, 40);
            this.buttonBubbleSort.TabIndex = 3;
            this.buttonBubbleSort.Text = "Bubble";
            this.buttonBubbleSort.UseVisualStyleBackColor = true;
            this.buttonBubbleSort.Click += new System.EventHandler(this.buttonBubbleSort_Click);
            // 
            // buttonInsertionSort
            // 
            this.buttonInsertionSort.Location = new System.Drawing.Point(430, 355);
            this.buttonInsertionSort.Name = "buttonInsertionSort";
            this.buttonInsertionSort.Size = new System.Drawing.Size(98, 40);
            this.buttonInsertionSort.TabIndex = 4;
            this.buttonInsertionSort.Text = "Insert";
            this.buttonInsertionSort.UseVisualStyleBackColor = true;
            this.buttonInsertionSort.Click += new System.EventHandler(this.buttonInsertionSort_Click);
            // 
            // buttonSelectionSort
            // 
            this.buttonSelectionSort.Location = new System.Drawing.Point(631, 355);
            this.buttonSelectionSort.Name = "buttonSelectionSort";
            this.buttonSelectionSort.Size = new System.Drawing.Size(100, 40);
            this.buttonSelectionSort.TabIndex = 5;
            this.buttonSelectionSort.Text = "Selection";
            this.buttonSelectionSort.UseVisualStyleBackColor = true;
            this.buttonSelectionSort.Click += new System.EventHandler(this.buttonSelectionSort_Click);
            // 
            // sortBubbleTime
            // 
            this.sortBubbleTime.AutoSize = true;
            this.sortBubbleTime.Location = new System.Drawing.Point(268, 339);
            this.sortBubbleTime.Name = "sortBubbleTime";
            this.sortBubbleTime.Size = new System.Drawing.Size(30, 13);
            this.sortBubbleTime.TabIndex = 6;
            this.sortBubbleTime.Text = "Time";
            // 
            // sortInsertTime
            // 
            this.sortInsertTime.AutoSize = true;
            this.sortInsertTime.Location = new System.Drawing.Point(464, 339);
            this.sortInsertTime.Name = "sortInsertTime";
            this.sortInsertTime.Size = new System.Drawing.Size(30, 13);
            this.sortInsertTime.TabIndex = 7;
            this.sortInsertTime.Text = "Time";
            // 
            // sortSelectionTime
            // 
            this.sortSelectionTime.AutoSize = true;
            this.sortSelectionTime.Location = new System.Drawing.Point(663, 339);
            this.sortSelectionTime.Name = "sortSelectionTime";
            this.sortSelectionTime.Size = new System.Drawing.Size(30, 13);
            this.sortSelectionTime.TabIndex = 8;
            this.sortSelectionTime.Text = "Time";
            // 
            // Sort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.sortSelectionTime);
            this.Controls.Add(this.sortInsertTime);
            this.Controls.Add(this.sortBubbleTime);
            this.Controls.Add(this.buttonSelectionSort);
            this.Controls.Add(this.buttonInsertionSort);
            this.Controls.Add(this.buttonBubbleSort);
            this.Controls.Add(this.buttonResetCurrentArray);
            this.Controls.Add(this.buttonPopulateArray);
            this.Controls.Add(this.label1);
            this.Name = "Sort";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPopulateArray;
        private System.Windows.Forms.Button buttonResetCurrentArray;
        private System.Windows.Forms.Button buttonBubbleSort;
        private System.Windows.Forms.Button buttonInsertionSort;
        private System.Windows.Forms.Button buttonSelectionSort;
        private System.Windows.Forms.Label sortBubbleTime;
        private System.Windows.Forms.Label sortInsertTime;
        private System.Windows.Forms.Label sortSelectionTime;
    }
}

