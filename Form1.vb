Public Class Form1

    'SORTEO: Generar una combinación aleatoria. 
    'Dicha combinación aparecerá ordenada ascendentemente. 
    'Para realizarla deberemos tener en cuenta:

    'a. Generaremos 6 números para la combinación (entre el 1 y el 49) 
    'y un número para el reintegro (entre el 0 y el 9), 
    'teniendo en cuenta que los números de la combinación no pueden ser repetidos, 
    'a través de una función denominada mostrar_resultados_sorteo. 
    'b. Para verificar si un número ha salido ya o no utilizaremos una función denominada repetido.
    'c. Ordenaremos los valores creando una función para ello, llamada ordenar.
    Dim panelResultado, panelPrimitiva, panelCombiWiner, panelCombiUser As Panel
    Dim ButtonBorrar, buttonManual As Button
    Dim reintegroBoleto As Integer
    Dim combiWinner As List(Of Integer)
    Private Sub mostrar_resultados_sorteo(x As Integer, y As Integer)
        Dim repetidoBoolean As Boolean
        Dim numPremiado, reintegro As Integer
        combiWinner = New List(Of Integer)
        ' generar reintegro
        reintegro = GetRandomInt(0, 9)
        ' Generar combinacion
        Do
            numPremiado = GetRandomInt(1, 49)
            repetidoBoolean = repetido(numPremiado, combiWinner)
            If repetidoBoolean = False Then
                combiWinner.Add(numPremiado)
            End If
        Loop While combiWinner.Count() < 6

        ordenar(combiWinner)
        mostrar_resultados_pantalla("panelCombiWiner", combiWinner, reintegro, x, y)
    End Sub

    Private Sub mostrar_resultados_pantalla(nombre As String, combiWinner As List(Of Integer), reintegro As Integer, x As Integer, y As Integer)
        Dim lblAux As Label
        Dim yPos, xPos, xPosAux As Integer
        Dim titulo As String
        If nombre = "panelCombiWiner" Then titulo = "Combinacion Ganadora"
        If nombre = "panelCombiUser" Then titulo = "Combinacion Usuario"
        panelResultado = New Panel
        panelResultado.Location = New Point(x, y)
        panelResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        panelResultado.Name = nombre
        panelResultado.Size = New System.Drawing.Size(325 + 30, 260)

        Me.Controls.Add(panelResultado)
        '
        'Label "Combinacion Ganadora"
        '
        xPos = 14
        yPos = 14

        lblAux = New Label()
        lblAux.BorderStyle = BorderStyle.Fixed3D
        lblAux.Location = New Point(xPos, yPos)
        lblAux.Size = New Size(325, 50)
        lblAux.Text = titulo
        lblAux.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        panelResultado.Controls.Add(lblAux)
        '
        'Label Numeros ganadores
        '
        yPos = yPos + 60
        xPosAux = xPos
        For Each numero As Integer In combiWinner
            lblAux = New Label()
            lblAux.Text = numero ' & "--" & xPos
            lblAux.Size = New Size(50, 50)
            lblAux.Location = New Point(xPosAux, yPos)
            lblAux.TextAlign = ContentAlignment.MiddleCenter
            lblAux.BorderStyle = BorderStyle.Fixed3D
            panelResultado.Controls.Add(lblAux)
            xPosAux = xPosAux + 55
        Next
        '
        'Label "Reintegro"
        '
        yPos += 60
        lblAux = New Label()
        lblAux.BorderStyle = BorderStyle.Fixed3D
        lblAux.Location = New Point(xPos, yPos)
        lblAux.Size = New Size(325, 50)
        lblAux.Text = "Reintegro"
        lblAux.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        panelResultado.Controls.Add(lblAux)

        '
        'Label Numero del Reintegro
        '
        yPos += 60
        lblAux = New Label()
        lblAux.Text = reintegro ' & "--" & xPos
        lblAux.Size = New Size(325, 50)
        lblAux.Location = New Point(xPos, yPos)
        lblAux.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        lblAux.BorderStyle = BorderStyle.Fixed3D
        panelResultado.Controls.Add(lblAux)

    End Sub

    Private Sub ordenar(combiWinner As List(Of Integer))
        combiWinner.Sort()
    End Sub

    Private Function repetido(numPremiado As Integer, combiWinner As List(Of Integer)) As Object
        Return combiWinner.Contains(numPremiado)
    End Function



    ''' <summary>
    ''' Generates a random Integer with any (inclusive) minimum or (inclusive) maximum values, with full range of Int32 values.
    ''' </summary>
    ''' <param name="inMin">Inclusive Minimum value. Lowest possible return value.</param>
    ''' <param name="inMax">Inclusive Maximum value. Highest possible return value.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRandomInt(inMin As Int32, inMax As Int32) As Int32
        Static staticRandomGenerator As New System.Random
        If inMin > inMax Then Dim t = inMin : inMin = inMax : inMax = t
        If inMax < Int32.MaxValue Then Return staticRandomGenerator.Next(inMin, inMax + 1)
        ' now max = Int32.MaxValue, so we need to work around Microsoft's quirk of an exclusive max parameter.
        If inMin > Int32.MinValue Then Return staticRandomGenerator.Next(inMin - 1, inMax) + 1 ' okay, this was the easy one.
        ' now min and max give full range of integer, but Random.Next() does not give us an option for the full range of integer.
        ' so we need to use Random.NextBytes() to give us 4 random bytes, then convert that to our random int.
        Dim bytes(3) As Byte ' 4 bytes, 0 to 3
        staticRandomGenerator.NextBytes(bytes) ' 4 random bytes
        Return BitConverter.ToInt32(bytes, 0) ' return bytes converted to a random Int32
    End Function

    Private Sub ButtonSorteo_Click(sender As Object, e As EventArgs) Handles ButtonSorteo.Click
        ocultarPaneles()
        mostrar_resultados_sorteo(250, 15)
    End Sub

    Private Sub ButtonPrimitiva_Click(sender As Object, e As EventArgs) Handles ButtonPrimitiva.Click
        ocultarPaneles()
        mostrar_panel_primitiva()

    End Sub

    Private Sub mostrar_panel_primitiva()
        crearPanel()
        crearCasillas()
        crearReintegro()
        crearBotones()
    End Sub

    Private Sub crearPanel()
        panelPrimitiva = New Panel
        panelPrimitiva.Location = New Point(250, 15)
        panelPrimitiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        panelPrimitiva.Name = "Panel1"
        panelPrimitiva.Size = New System.Drawing.Size(60 * 7 + 10 * 6 + 30, 50 * 7 + 30 + 60)
        Me.Controls.Add(panelPrimitiva)
    End Sub

    Private Sub crearReintegro()
        Dim xPos, yPos As Integer
        Dim lblAux As Label
        Dim txtAux As TextBox
        '
        'Label borde
        '
        xPos = 15
        yPos = 14 + (50 * 7)

        lblAux = New Label()
        lblAux.BorderStyle = BorderStyle.Fixed3D
        lblAux.Location = New Point(xPos, yPos)
        lblAux.Size = New Size(90, 60)
        lblAux.TextAlign = ContentAlignment.MiddleLeft
        lblAux.Text = " R:"
        '
        'TextBox1
        '
        txtAux = New TextBox()
        txtAux.Enabled = False
        txtAux.Location = New System.Drawing.Point(xPos + 40, yPos + 14)
        txtAux.Font = New Font("Microsoft Sans Serif", 16.0!, FontStyle.Bold,
                              GraphicsUnit.Point, CType(0, Byte))

        txtAux.BackColor = SystemColors.HighlightText
        txtAux.Size = New Size(42, 30)
        txtAux.TabIndex = 5

        txtAux.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        reintegroBoleto = GetRandomInt(0, 9)
        txtAux.Text = reintegroBoleto
        panelPrimitiva.Controls.Add(txtAux)
        panelPrimitiva.Controls.Add(lblAux)

    End Sub

    Private Sub crearBotones()
        Dim xPos, yPos As Integer
        Dim lblAux As Label
        Dim btnAux As Button
        Dim lblXsize As Integer = 120
        '
        'Label borde
        '
        xPos = 15 + 100
        yPos = 14 + (50 * 7)
        lblAux = New Label()
        lblAux.BorderStyle = BorderStyle.Fixed3D
        lblAux.Location = New Point(xPos, yPos)
        lblAux.Size = New Size(lblXsize, 60)
        lblAux.Text = ""
        '
        'ButtonManual
        '
        buttonManual = New Button()
        buttonManual.Location = New Point(xPos + 10, yPos + 10)
        buttonManual.Name = "ButtonManual"
        buttonManual.Size = New Size(100, 40)
        buttonManual.TabIndex = 5
        buttonManual.Text = "Manual"
        AddHandler buttonManual.Click, AddressOf ButtonManual_Click
        buttonManual.UseVisualStyleBackColor = True

        panelPrimitiva.Controls.Add(buttonManual)
        panelPrimitiva.Controls.Add(lblAux)
        '
        'Label borde
        '
        xPos = xPos + lblXsize + 10
        lblAux = New Label()
        lblAux.BorderStyle = BorderStyle.Fixed3D
        lblAux.Location = New Point(xPos, yPos)
        lblAux.Size = New Size(lblXsize, 60)
        lblAux.Text = ""
        '
        'ButtonBorrar
        '
        ButtonBorrar = New Button()
        ButtonBorrar.Location = New Point(xPos + 10, yPos + 10)
        ButtonBorrar.Name = "ButtonBorrar"
        ButtonBorrar.Size = New Size(100, 40)
        ButtonBorrar.Text = "Borrar"
        ButtonBorrar.UseVisualStyleBackColor = True
        AddHandler ButtonBorrar.Click, AddressOf ButtonBorrar_Click
        panelPrimitiva.Controls.Add(ButtonBorrar)
        panelPrimitiva.Controls.Add(lblAux)
        '
        'Label borde
        '
        xPos = xPos + lblXsize + 10

        lblAux = New Label()
        lblAux.BorderStyle = BorderStyle.Fixed3D
        lblAux.Location = New Point(xPos, yPos)
        lblAux.Size = New Size(lblXsize, 60)
        lblAux.Text = ""

        '
        'ButtonAutomatica
        '
        btnAux = New Button()
        btnAux.Location = New Point(xPos + 10, yPos + 10)
        btnAux.Name = "ButtonAutomatica"
        btnAux.Size = New Size(100, 40)
        btnAux.TabIndex = 5
        btnAux.Text = "Automatica"
        btnAux.UseVisualStyleBackColor = True

        panelPrimitiva.Controls.Add(btnAux)
        panelPrimitiva.Controls.Add(lblAux)


    End Sub

    Private Sub crearCasillas()
        Dim lblAux As Label
        Dim checkBoxAux As CheckBox
        Dim yPos, xPos As Integer
        Dim contador As Integer
        Dim AltLbl As Integer = 40
        yPos = 14
        contador = 0

        For i = 1 To 7
            xPos = 14
            For j = 1 To 7
                contador += 1
                ' Cada label
                lblAux = New Label()
                lblAux.Text = contador
                lblAux.Size = New Size(60, AltLbl)
                lblAux.Location = New Point(xPos, yPos)
                lblAux.TextAlign = ContentAlignment.MiddleCenter
                lblAux.BorderStyle = BorderStyle.Fixed3D
                '  ----
                checkBoxAux = New CheckBox()
                checkBoxAux.AutoSize = True
                checkBoxAux.Location = New Point(xPos + 40, yPos + 14)
                checkBoxAux.Name = "CheckBox" & contador
                checkBoxAux.Size = New System.Drawing.Size(18, 18)
                checkBoxAux.UseVisualStyleBackColor = True
                checkBoxAux.Tag = 1

                panelPrimitiva.Controls.Add(checkBoxAux)
                panelPrimitiva.Controls.Add(lblAux)
                xPos += 70
            Next
            yPos += 50
        Next


    End Sub


    Private Sub ButtonBorrar_Click()
        If panelPrimitiva IsNot Nothing Then
            panelPrimitiva.Hide()
        End If
        mostrar_panel_primitiva()
    End Sub


    Private Sub ButtonManual_Click()
        '      Existirá un botón “manual”, que al pulsarlo actuará de la siguiente forma

        'a) DATOS INCORRECTOS: mostrará un mensaje de error. 
        'b) DATOS CORRECTOS: (6 valores marcados), mostrará:
        'la combinación del usuario
        'el sorteo
        'un recuento de aciertos indicando la devolución del dinero en caso de que coincidan los reintegros (usando una función denominada mostrar_resultados) y mostrada en otro formulario
        Dim listaUser As List(Of Integer)
        Dim datos As Boolean
        listaUser = recoger_combinacion_usuario()
        datos = comprobar_datos(listaUser)
        If Not datos Then
            MessageBox.Show("Selecciona 6 casillas")
        Else
            ocultarPaneles()
            mostrar_resultados_sorteo(200, 300)
            mostrar_combinacion_usuario(listaUser, 200, 15)
            ' comprobarPremio(listaUser)

        End If
    End Sub

    Private Sub comprobarPremio(lista As List(Of Integer))
        Throw New NotImplementedException()
    End Sub

    Private Sub ocultarPaneles()
        If panelResultado IsNot Nothing Then
            panelResultado.Hide()
        End If
        If panelPrimitiva IsNot Nothing Then
            panelPrimitiva.Hide()
        End If
        If panelCombiWiner IsNot Nothing Then
            panelCombiWiner.Hide()
        End If
    End Sub
    Private Sub mostrar_combinacion_usuario(lista As List(Of Integer), x As Integer, y As Integer)
        mostrar_resultados_pantalla("panelCombiUser", lista, reintegroBoleto, x, y)
    End Sub

    Private Function comprobar_datos(lista As List(Of Integer)) As Boolean
        Dim datos As Boolean = False
        If IsNothing(lista) Then
            datos = False
        ElseIf lista.Count = 6 Then
            datos = True
        End If

        Return datos
    End Function

    Private Function recoger_combinacion_usuario()
        'recoger los checkbox
        Dim lista As List(Of Integer)
        lista = New List(Of Integer)
        For i = 0 To panelPrimitiva.Controls.Count - 1
            If panelPrimitiva.Controls(i).Tag = 1 Then
                Dim cbAux As CheckBox = panelPrimitiva.Controls(i)
                If cbAux.Checked Then
                    Dim id As String = cbAux.Name
                    Dim num = Integer.Parse(id.Substring(8))

                    lista.Add(num)
                End If
            End If
        Next
        Return lista
    End Function
End Class
