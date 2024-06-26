﻿using WaferMapLibrary;

namespace CommonComponentLibrary
{
    partial class WaferMapCanvas
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            WaferMap.OnIndexChange -= Test;
            this._backgroundBitmap?.Dispose();
            this._backgroundBitmap = null;
            this._simplifiedBitmap?.Dispose();
            this._simplifiedBitmap = null;
            this.canvas.Image?.Dispose();
            this.canvas.Image = null;
            base.Dispose(disposing);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // WaferMapCanvas
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Name = "WaferMapCanvas";
            Size = new Size(670, 599);
            Load += WaferMapCanvas_Load;
            MouseDown += WaferMapCanvas_MouseDown;
            ResumeLayout(false);
        }

        #endregion
    }
}
