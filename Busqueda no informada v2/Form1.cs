using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Busqueda_no_informada_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox4.Controls.Clear();
            int filas, columnas, contador = 1;
            filas = Convert.ToInt32(textBox3.Text);
            columnas = Convert.ToInt32(textBox4.Text);
            Button[,] boton = new Button[filas, columnas];
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    boton[i, j] = new Button();
                    boton[i, j].Width = 40;
                    boton[i, j].Height = 40;
                    boton[i, j].Top = i * 40;
                    boton[i, j].Left = j * 40;
                    boton[i, j].Text = String.Format("" + contador);
                    groupBox4.Controls.Add(boton[i, j]);
                    contador++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n_filas = Convert.ToInt32(textBox3.Text);
            int n_columnas = Convert.ToInt32(textBox4.Text);
            int contador_p = 1;
            int inicio = Convert.ToInt32(textBox1.Text);
            int final = Convert.ToInt32(textBox2.Text);
            Random rnd = new Random();
            int[,] camino = new int[100, n_filas * n_columnas];
            int[] movimientos_tot = new int[100];
            int iteraciones = 0;
            int it_menor_mov = 0;
            int inicio_original = inicio;

            if (inicio < final)
            {
                for (int r = 0; r < 100; r++)
                {
                    inicio = inicio_original;
                    int cont_mov = 1;
                    camino[iteraciones, 0] = inicio;
                    bool bandera = false;

                    //INICIO DE UN POSIBLE CAMINO
                    while (inicio != final)
                    {

                        Console.WriteLine("Estoy en el nodo " + inicio);

                        int cont = 1;
                        int a1 = 0, b1 = 0;
                        for (int a = 0; a < n_filas; a++)
                        {
                            for (int b = 0; b < n_columnas; b++)
                            {
                                if (cont == inicio)
                                {
                                    a1 = a;
                                    b1 = b;
                                    a = n_filas;
                                    break;
                                }
                                cont++;
                            }
                        }
                        contador_p = cont;
                        //Console.WriteLine(a1 + " " + b1);
                        int fila = a1;
                        int columna = b1;
                        bandera = false;

                        if (textBox5.Text != "" && Convert.ToInt32(textBox5.Text) == inicio)
                        {
                            inicio = final;
                            cont_mov += 100;
                            bandera = true;
                        }
                        if (textBox6.Text != "" && Convert.ToInt32(textBox6.Text) == inicio)
                        {
                            inicio = final;
                            cont_mov += 100;
                            bandera = true;
                        }
                        if (textBox6.Text != "" && Convert.ToInt32(textBox6.Text) == inicio)
                        {
                            inicio = final;
                            cont_mov += 100;
                            bandera = true;
                        }

                        if (!bandera)
                        {
                            if (fila == 0)
                            {
                                if (fila == 0 && columna == 0)
                                {
                                    //Esquina superior izquierda
                                    Console.Write("" + contador_p + " ESQSI ");
                                    int[] movimientos = new int[2];
                                    movimientos[0] = contador_p + 1;
                                    movimientos[1] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(2);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else if (fila == 0 && columna == (n_columnas - 1))
                                {
                                    //Esquina superior derecha
                                    Console.Write("" + contador_p + " ESQSD");
                                    int[] movimientos = new int[2];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(2);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else
                                {
                                    //Orilla superior
                                    Console.Write("" + contador_p + " ORLLS ");
                                    int[] movimientos = new int[3];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p + 1;
                                    movimientos[2] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(3);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                            }
                            else if (fila == (n_filas - 1))
                            {
                                if (fila == (n_filas - 1) && columna == 0)
                                {
                                    //Esquina inferior izquierda
                                    Console.Write("" + contador_p + " ESQII ");
                                    int[] movimientos = new int[2];
                                    movimientos[0] = contador_p + 1;
                                    movimientos[1] = contador_p - n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(2);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else if (fila == (n_filas - 1) && columna == (n_columnas - 1))
                                {
                                    //Esquina inferior derecha
                                    Console.Write("" + contador_p + " ESQID ");
                                    int[] movimientos = new int[2];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p - n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(2);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                    else
                                    {
                                        inicio = final;
                                        cont_mov *= 2;
                                    }
                                }
                                else
                                {
                                    //Orilla inferior
                                    Console.Write("" + contador_p + " ORLLI ");
                                    int[] movimientos = new int[3];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p + 1;
                                    movimientos[2] = contador_p - n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(3);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                            }
                            else
                            {
                                if (columna == 0)
                                {
                                    //Orilla Izquierda
                                    Console.Write("" + contador_p + " ORLLIZ ");
                                    int[] movimientos = new int[3];
                                    movimientos[0] = contador_p + 1;
                                    movimientos[1] = contador_p - n_columnas;
                                    movimientos[2] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(3);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else if (columna == (n_columnas - 1))
                                {
                                    //Orilla derecha
                                    Console.Write("" + contador_p + " ORLLD ");
                                    int[] movimientos = new int[3];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p - n_columnas;
                                    movimientos[2] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(3);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else
                                {
                                    //En medio
                                    Console.Write("" + contador_p + " MED ");
                                    int[] movimientos = new int[4];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p + 1;
                                    movimientos[2] = contador_p - n_columnas;
                                    movimientos[3] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(4);
                                    if (movimientos[numero_random] > camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                            }
                        }




                        //Console.WriteLine();

                    }
                    //FINAL DE UN POSIBLE CAMINO

                    if (!bandera)
                    {
                        //IMPRESIÓN DE POSIBLE CAMINO
                        Console.WriteLine("Estoy en el nodo " + final);
                        Console.WriteLine();
                        Console.WriteLine("El camino es: ");
                        Console.WriteLine("movimientos" + cont_mov);
                        for (int z = 0; z < cont_mov; z++)
                        {
                            Console.WriteLine(">" + camino[iteraciones, z]);
                        }
                    }


                    movimientos_tot[r] = cont_mov;
                    if (r > 0)
                    {
                        if (movimientos_tot[r] < movimientos_tot[r - 1])
                            it_menor_mov = iteraciones;
                    }
                    else
                    {
                        it_menor_mov = 0;
                    }
                    iteraciones++;
                }
                //IMPRIMIMOS EL CAMINO MÁS CORTO
                groupBox4.Controls.Clear();
                int filas, columnas, contador = 1;
                filas = Convert.ToInt32(textBox3.Text);
                columnas = Convert.ToInt32(textBox4.Text);
                Button[,] boton = new Button[filas, columnas];
                Console.WriteLine("EL CAMINO FINAL MÁS CORTO ES: ");
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        boton[i, j] = new Button();
                        for (int z = 0; z < movimientos_tot[it_menor_mov]; z++)
                        {
                            //Console.WriteLine(camino[it_menor_mov, z]);
                            if (contador == camino[it_menor_mov, z])
                                boton[i, j].BackColor = Color.Green;
                        }
                        boton[i, j].Width = 40;
                        boton[i, j].Height = 40;
                        boton[i, j].Top = i * 40;
                        boton[i, j].Left = j * 40;
                        boton[i, j].Text = String.Format("" + contador);
                        groupBox4.Controls.Add(boton[i, j]);
                        contador++;
                    }
                }
            }
            else
            {
                for (int r = 0; r < 100; r++)
                {
                    inicio = inicio_original;
                    int cont_mov = 1;
                    camino[iteraciones, 0] = inicio;
                    bool bandera = false;

                    //INICIO DE UN POSIBLE CAMINO
                    while (inicio != final)
                    {

                        Console.WriteLine("Estoy en el nodo " + inicio);

                        int cont = 1;
                        int a1 = 0, b1 = 0;
                        for (int a = 0; a < n_filas; a++)
                        {
                            for (int b = 0; b < n_columnas; b++)
                            {
                                if (cont == inicio)
                                {
                                    a1 = a;
                                    b1 = b;
                                    a = n_filas;
                                    break;
                                }
                                cont++;
                            }
                        }
                        contador_p = cont;
                        //Console.WriteLine(a1 + " " + b1);
                        int fila = a1;
                        int columna = b1;
                        bandera = false;

                        if (textBox5.Text != "" && Convert.ToInt32(textBox5.Text) == inicio)
                        {
                            inicio = final;
                            cont_mov += 100;
                            bandera = true;
                        }
                        if (textBox6.Text != "" && Convert.ToInt32(textBox6.Text) == inicio)
                        {
                            inicio = final;
                            cont_mov += 100;
                            bandera = true;
                        }
                        if (textBox6.Text != "" && Convert.ToInt32(textBox6.Text) == inicio)
                        {
                            inicio = final;
                            cont_mov += 100;
                            bandera = true;
                        }

                        if (!bandera)
                        {
                            if (fila == 0)
                            {
                                if (fila == 0 && columna == 0)
                                {
                                    //Esquina superior izquierda
                                    Console.Write("" + contador_p + " ESQSI ");
                                    int[] movimientos = new int[2];
                                    movimientos[0] = contador_p + 1;
                                    movimientos[1] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(2);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else if (fila == 0 && columna == (n_columnas - 1))
                                {
                                    //Esquina superior derecha
                                    Console.Write("" + contador_p + " ESQSD");
                                    int[] movimientos = new int[2];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(2);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else
                                {
                                    //Orilla superior
                                    Console.Write("" + contador_p + " ORLLS ");
                                    int[] movimientos = new int[3];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p + 1;
                                    movimientos[2] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(3);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                            }
                            else if (fila == (n_filas - 1))
                            {
                                if (fila == (n_filas - 1) && columna == 0)
                                {
                                    //Esquina inferior izquierda
                                    Console.Write("" + contador_p + " ESQII ");
                                    int[] movimientos = new int[2];
                                    movimientos[0] = contador_p + 1;
                                    movimientos[1] = contador_p - n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(2);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else if (fila == (n_filas - 1) && columna == (n_columnas - 1))
                                {
                                    //Esquina inferior derecha
                                    Console.Write("" + contador_p + " ESQID ");
                                    int[] movimientos = new int[2];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p - n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(2);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                    else
                                    {
                                        inicio = final;
                                        cont_mov *= 2;
                                    }
                                }
                                else
                                {
                                    //Orilla inferior
                                    Console.Write("" + contador_p + " ORLLI ");
                                    int[] movimientos = new int[3];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p + 1;
                                    movimientos[2] = contador_p - n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(3);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                            }
                            else
                            {
                                if (columna == 0)
                                {
                                    //Orilla Izquierda
                                    Console.Write("" + contador_p + " ORLLIZ ");
                                    int[] movimientos = new int[3];
                                    movimientos[0] = contador_p + 1;
                                    movimientos[1] = contador_p - n_columnas;
                                    movimientos[2] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(3);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else if (columna == (n_columnas - 1))
                                {
                                    //Orilla derecha
                                    Console.Write("" + contador_p + " ORLLD ");
                                    int[] movimientos = new int[3];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p - n_columnas;
                                    movimientos[2] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(3);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                                else
                                {
                                    //En medio
                                    Console.Write("" + contador_p + " MED ");
                                    int[] movimientos = new int[4];
                                    movimientos[0] = contador_p - 1;
                                    movimientos[1] = contador_p + 1;
                                    movimientos[2] = contador_p - n_columnas;
                                    movimientos[3] = contador_p + n_columnas;
                                    int numero_random;
                                    numero_random = rnd.Next(4);
                                    if (movimientos[numero_random] < camino[iteraciones, cont_mov - 1] || movimientos[numero_random] == final)
                                    {
                                        Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                        inicio = movimientos[numero_random];
                                        camino[iteraciones, cont_mov] = movimientos[numero_random];
                                        cont_mov++;
                                    }
                                }
                            }
                        }




                        //Console.WriteLine();

                    }
                    //FINAL DE UN POSIBLE CAMINO

                    if (!bandera)
                    {
                        //IMPRESIÓN DE POSIBLE CAMINO
                        Console.WriteLine("Estoy en el nodo " + final);
                        Console.WriteLine();
                        Console.WriteLine("El camino es: ");
                        Console.WriteLine("movimientos" + cont_mov);
                        for (int z = 0; z < cont_mov; z++)
                        {
                            Console.WriteLine(">" + camino[iteraciones, z]);
                        }
                    }


                    movimientos_tot[r] = cont_mov;
                    if (r > 0)
                    {
                        if (movimientos_tot[r] < movimientos_tot[r - 1])
                            it_menor_mov = iteraciones;
                    }
                    else
                    {
                        it_menor_mov = 0;
                    }
                    iteraciones++;
                }
                //IMPRIMIMOS EL CAMINO MÁS CORTO
                groupBox4.Controls.Clear();
                int filas, columnas, contador = 1;
                filas = Convert.ToInt32(textBox3.Text);
                columnas = Convert.ToInt32(textBox4.Text);
                Button[,] boton = new Button[filas, columnas];
                Console.WriteLine("EL CAMINO FINAL MÁS CORTO ES: ");
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        boton[i, j] = new Button();
                        for (int z = 0; z < movimientos_tot[it_menor_mov]; z++)
                        {
                            //Console.WriteLine(camino[it_menor_mov, z]);
                            if (contador == camino[it_menor_mov, z])
                                boton[i, j].BackColor = Color.Green;
                        }
                        boton[i, j].Width = 40;
                        boton[i, j].Height = 40;
                        boton[i, j].Top = i * 40;
                        boton[i, j].Left = j * 40;
                        boton[i, j].Text = String.Format("" + contador);
                        groupBox4.Controls.Add(boton[i, j]);
                        contador++;
                    }
                }
            }            


            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n_filas = Convert.ToInt32(textBox3.Text);
            int n_columnas = Convert.ToInt32(textBox4.Text);
            int contador_p = 1;
            int inicio = Convert.ToInt32(textBox1.Text);
            int final = Convert.ToInt32(textBox2.Text);
            Random rnd = new Random();
            int[,] camino = new int[100, 100];
            int[] movimientos_tot = new int[100];
            int iteraciones = 0;
            int it_menor_mov = 0;
            int inicio_original = inicio;
            int numero_menor = 0;
            int caminos_encontrados=0, caminos_buenos=0, caminos_incompletos=0;

            for (int r = 0; r < 100; r++)
            {
                inicio = inicio_original;
                int cont_mov = 1;
                camino[iteraciones, 0] = inicio;
                bool bandera = false;

                //INICIO DE UN POSIBLE CAMINO
                while (inicio != final)
                {

                    Console.WriteLine("Estoy en el nodo " + inicio);

                    int cont = 1;
                    int a1 = 0, b1 = 0;
                    for (int a = 0; a < n_filas; a++)
                    {
                        for (int b = 0; b < n_columnas; b++)
                        {
                            if (cont == inicio)
                            {
                                a1 = a;
                                b1 = b;
                                a = n_filas;
                                break;
                            }
                            cont++;
                        }
                    }
                    contador_p = cont;
                    //Console.WriteLine(a1 + " " + b1);
                    int fila = a1;
                    int columna = b1;
                    bandera = false;

                    if (textBox5.Text != "" && Convert.ToInt32(textBox5.Text) == inicio)
                    {
                        inicio = final;
                        cont_mov += 100;
                        bandera = true;
                    }
                    if (textBox6.Text != "" && Convert.ToInt32(textBox6.Text) == inicio)
                    {
                        inicio = final;
                        cont_mov += 100;
                        bandera = true;
                    }
                    if (textBox7.Text != "" && Convert.ToInt32(textBox7.Text) == inicio)
                    {
                        inicio = final;
                        cont_mov += 100;
                        bandera = true;
                    }

                    if (!bandera)
                    {
                        if (fila == 0)
                        {
                            if (fila == 0 && columna == 0)
                            {
                                //Esquina superior izquierda
                                //Console.Write("" + contador_p + " ESQSI ");
                                int[] movimientos = new int[2];
                                movimientos[0] = contador_p + 1;
                                movimientos[1] = contador_p + n_columnas;
                                if (inicio < final)
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[1] + "\t\t");
                                    inicio = movimientos[0];
                                    camino[iteraciones, cont_mov] = movimientos[0];
                                    cont_mov++;

                                }
                                else
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[0] + "\t\t");
                                    inicio = movimientos[1];
                                    camino[iteraciones, cont_mov] = movimientos[1];
                                    cont_mov++;
                                }                                
                            }
                            else if (fila == 0 && columna == (n_columnas - 1))
                            {
                                //Esquina superior derecha
                                //Console.Write("" + contador_p + " ESQSD");
                                int[] movimientos = new int[2];
                                movimientos[0] = contador_p - 1;
                                movimientos[1] = contador_p + n_columnas;
                                if (inicio < final)
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[1] + "\t\t");
                                    inicio = movimientos[1];
                                    camino[iteraciones, cont_mov] = movimientos[1];
                                    cont_mov++;

                                }
                                else
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[0] + "\t\t");
                                    inicio = movimientos[0];
                                    camino[iteraciones, cont_mov] = movimientos[0];
                                    cont_mov++;
                                }
                            }
                            else
                            {
                                //Orilla superior
                                //Console.Write("" + contador_p + " ORLLS ");
                                int[] movimientos = new int[3];
                                movimientos[0] = contador_p + 1;
                                movimientos[1] = contador_p + n_columnas;
                                movimientos[2] = contador_p - 1;
                                int numero_random;
                                numero_random = rnd.Next(2);
                                if (inicio < final)
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                    inicio = movimientos[numero_random];
                                    camino[iteraciones, cont_mov] = movimientos[numero_random];
                                    cont_mov++;
                                }
                                else
                                {

                                    //Console.Write("Me muevo al nodo " + movimientos[2] + "\t\t");
                                    inicio = movimientos[2];
                                    camino[iteraciones, cont_mov] = movimientos[2];
                                    cont_mov++;
                                }
                            }
                        }
                        else if (fila == (n_filas - 1))
                        {
                            if (fila == (n_filas - 1) && columna == 0)
                            {
                                //Esquina inferior izquierda
                                //Console.Write("" + contador_p + " ESQII ");
                                int[] movimientos = new int[2];
                                movimientos[0] = contador_p + 1;
                                movimientos[1] = contador_p - n_columnas;
                                if (inicio < final)
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[0] + "\t\t");
                                    inicio = movimientos[0];
                                    camino[iteraciones, cont_mov] = movimientos[0];
                                    cont_mov++;
                                }
                                else
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[1] + "\t\t");
                                    inicio = movimientos[1];
                                    camino[iteraciones, cont_mov] = movimientos[1];
                                    cont_mov++;
                                }
                            }
                            else if (fila == (n_filas - 1) && columna == (n_columnas - 1))
                            {
                                //Esquina inferior derecha
                                //Console.Write("" + contador_p + " ESQID ");
                                int[] movimientos = new int[2];
                                movimientos[0] = contador_p - 1;
                                movimientos[1] = contador_p - n_columnas;
                                if (inicio < final)
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[1] + "\t\t");
                                    inicio = movimientos[1];
                                    camino[iteraciones, cont_mov] = movimientos[1];
                                    cont_mov++;
                                }
                                else
                                {
                                    inicio = movimientos[0];
                                    camino[iteraciones, cont_mov] = movimientos[0];
                                    cont_mov++;

                                }

                            }
                            else
                            {
                                //Orilla inferior
                                //Console.Write("" + contador_p + " ORLLI ");
                                int[] movimientos = new int[3];
                                movimientos[0] = contador_p - 1;
                                movimientos[1] = contador_p - n_columnas;
                                movimientos[2] = contador_p + 1;
                                int numero_random;
                                numero_random = rnd.Next(2);
                                if (inicio < final)
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[2] + "\t\t");
                                    inicio = movimientos[2];
                                    camino[iteraciones, cont_mov] = movimientos[2];
                                    cont_mov++;                                    
                                }
                                else
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                    inicio = movimientos[numero_random];
                                    camino[iteraciones, cont_mov] = movimientos[numero_random];
                                    cont_mov++;

                                }
                            }
                        }
                        else
                        {
                            if (columna == 0)
                            {
                                //Orilla Izquierda
                                //Console.Write("" + contador_p + " ORLLIZ ");
                                int[] movimientos = new int[3];
                                movimientos[0] = contador_p + 1;
                                movimientos[1] = contador_p + n_columnas;
                                movimientos[2] = contador_p - n_columnas;
                                int numero_random;
                                numero_random = rnd.Next(2);
                                if (inicio < final)
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                    inicio = movimientos[numero_random];
                                    camino[iteraciones, cont_mov] = movimientos[numero_random];
                                    cont_mov++;
                                }
                                else
                                {

                                    //Console.Write("Me muevo al nodo " + movimientos[2] + "\t\t");
                                    inicio = movimientos[2];
                                    camino[iteraciones, cont_mov] = movimientos[2];
                                    cont_mov++;
                                }
                            }
                            else if (columna == (n_columnas - 1))
                            {
                                //Orilla derecha
                                //Console.Write("" + contador_p + " ORLLD ");
                                int[] movimientos = new int[3];
                                movimientos[0] = contador_p - 1;
                                movimientos[1] = contador_p - n_columnas;
                                movimientos[2] = contador_p + n_columnas;
                                int numero_random;
                                numero_random = rnd.Next(2);
                                if (inicio < final)
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[2] + "\t\t");
                                    inicio = movimientos[2];
                                    camino[iteraciones, cont_mov] = movimientos[2];
                                    cont_mov++;                                    
                                }
                                else
                                {
                                    //Console.Write("Me muevo al nodo " + movimientos[numero_random] + "\t\t");
                                    inicio = movimientos[numero_random];
                                    camino[iteraciones, cont_mov] = movimientos[numero_random];
                                    cont_mov++;

                                }
                            }
                            else
                            {
                                //En medio
                                Console.Write("" + contador_p + " MED ");
                                int[] movimientos = new int[2];
                                int[] movimientos2 = new int[2];                                
                                movimientos[0] = contador_p + 1;
                                movimientos[1] = contador_p + n_columnas;
                                movimientos2[0] = contador_p - 1;
                                movimientos2[1] = contador_p - n_columnas;
                                int numero_random, numero_random2;
                                numero_random = rnd.Next(2);
                                numero_random2 = rnd.Next(2);
                                if (inicio < final)
                                {
                                    inicio = movimientos[numero_random];
                                    camino[iteraciones, cont_mov] = movimientos[numero_random];
                                    cont_mov++;

                                }
                                else
                                {
                                    inicio = movimientos2[numero_random2];
                                    camino[iteraciones, cont_mov] = movimientos2[numero_random2];
                                    cont_mov++;

                                }
                            }
                        }
                    }




                    //Console.WriteLine();

                }
                //FINAL DE UN POSIBLE CAMINO

                if (!bandera)
                {
                    //IMPRESIÓN DE POSIBLE CAMINO
                    Console.WriteLine("Estoy en el nodo " + final);
                    Console.WriteLine();
                    Console.WriteLine("El camino es: ");
                    Console.WriteLine("movimientos" + cont_mov);
                    for (int z = 0; z < cont_mov; z++)
                    {
                        Console.WriteLine(">" + camino[iteraciones, z]);
                    }
                }


                movimientos_tot[r] = cont_mov;
                if (r > 0)
                {
                    if (cont_mov < numero_menor)
                    {
                        numero_menor = cont_mov;
                        it_menor_mov = iteraciones;
                        Console.WriteLine("Camino corto nuevo encontrado en la iteración: " + r);
                        Console.WriteLine("La cantidad de movimientos guardados es: " + movimientos_tot[r]);
                    }

                    if (movimientos_tot[r] != movimientos_tot[r - 1])
                    {
                        caminos_buenos++;
                    }
                }
                else
                {
                    numero_menor = cont_mov;
                }
                if (cont_mov > 90)
                {
                    caminos_incompletos++;
                }
                iteraciones++;
            }
            //IMPRIMIMOS EL CAMINO MÁS CORTO
            groupBox4.Controls.Clear();
            int filas, columnas, contador = 1;
            int peso=0;
            filas = Convert.ToInt32(textBox3.Text);
            columnas = Convert.ToInt32(textBox4.Text);
            Button[,] boton = new Button[filas, columnas];
            Console.WriteLine("EL CAMINO FINAL MÁS CORTO ES: ");
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    boton[i, j] = new Button();
                    for (int z = 0; z < movimientos_tot[it_menor_mov]; z++)
                    {
                        //Console.WriteLine(camino[it_menor_mov, z]);
                        if (contador == camino[it_menor_mov, z])
                            boton[i, j].BackColor = Color.Green;
                    }
                    boton[i, j].Width = 40;
                    boton[i, j].Height = 40;
                    boton[i, j].Top = i * 40;
                    boton[i, j].Left = j * 40;
                    boton[i, j].Text = String.Format("" + contador);
                    groupBox4.Controls.Add(boton[i, j]);
                    contador++;
                }
            }

            for (int z = 0; z < movimientos_tot[it_menor_mov]; z++)
            {
                peso++;
            }
            caminos_encontrados = 100 - caminos_incompletos;

            Console.WriteLine("caminos incompletos: " + caminos_incompletos);
            Console.WriteLine("caminos encontrados y buenos: " + caminos_encontrados);
            Console.WriteLine("Peso del camino: " + peso);
        }
    }
}
