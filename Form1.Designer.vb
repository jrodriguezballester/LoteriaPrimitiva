<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ButtonSorteo = New System.Windows.Forms.Button()
        Me.ButtonPrimitiva = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonSorteo
        '
        Me.ButtonSorteo.Location = New System.Drawing.Point(18, 14)
        Me.ButtonSorteo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonSorteo.Name = "ButtonSorteo"
        Me.ButtonSorteo.Size = New System.Drawing.Size(112, 36)
        Me.ButtonSorteo.TabIndex = 3
        Me.ButtonSorteo.Text = "Sorteo"
        Me.ButtonSorteo.UseVisualStyleBackColor = True
        '
        'ButtonPrimitiva
        '
        Me.ButtonPrimitiva.Location = New System.Drawing.Point(18, 58)
        Me.ButtonPrimitiva.Name = "ButtonPrimitiva"
        Me.ButtonPrimitiva.Size = New System.Drawing.Size(112, 36)
        Me.ButtonPrimitiva.TabIndex = 4
        Me.ButtonPrimitiva.Text = "Primitiva"
        Me.ButtonPrimitiva.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 703)
        Me.Controls.Add(Me.ButtonPrimitiva)
        Me.Controls.Add(Me.ButtonSorteo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonSorteo As Button
    Friend WithEvents ButtonPrimitiva As Button
End Class
