<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class REMOVEUSER
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.LLOGINBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LIBRARYDataSet = New LIBRARY_LATEST.LIBRARYDataSet()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LLOGINTableAdapter = New LIBRARY_LATEST.LIBRARYDataSetTableAdapters.LLOGINTableAdapter()
        Me.GroupBox1.SuspendLayout()
        CType(Me.LLOGINBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LIBRARYDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Modern No. 20", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(103, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "UserName"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 207)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Info"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(62, 101)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(234, 29)
        Me.ComboBox1.TabIndex = 36
        '
        'LLOGINBindingSource
        '
        Me.LLOGINBindingSource.DataMember = "LLOGIN"
        Me.LLOGINBindingSource.DataSource = Me.LIBRARYDataSet
        '
        'LIBRARYDataSet
        '
        Me.LIBRARYDataSet.DataSetName = "LIBRARYDataSet"
        Me.LIBRARYDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Perpetua Titling MT", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(94, 253)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(195, 44)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Remove"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'LLOGINTableAdapter
        '
        Me.LLOGINTableAdapter.ClearBeforeFill = True
        '
        'REMOVEUSER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.LIBRARY_LATEST.My.Resources.Resources._1200px_Bibliothèque_de_l_Assemblée_Nationale__Lunon_1
        Me.ClientSize = New System.Drawing.Size(422, 327)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "REMOVEUSER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REMOVE AN EXISTING USER"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.LLOGINBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LIBRARYDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents LIBRARYDataSet As LIBRARYDataSet
    Friend WithEvents LLOGINBindingSource As BindingSource
    Friend WithEvents LLOGINTableAdapter As LIBRARYDataSetTableAdapters.LLOGINTableAdapter
End Class
