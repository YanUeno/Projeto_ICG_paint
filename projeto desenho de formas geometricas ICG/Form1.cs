/* *******************************************************************
 * Colegio Técnico Antônio Teixeira Fernandes (Univap)
 * Curso Técnico em Informática - Data de Entrega: 24/07/2020
 * Autores do Projeto: Yan Massahiro ueno
 *                     Erick Alberto Bruno da Silva
 * Turma: 3F
 * Avaliação parcial referente ao 2 - Bimestre
 * Observação: <colocar se houver>
 * 
 * 
 * ******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//variavel forma define a fora(1-2-3-4-5)||
//variavel x,y define a localizacao do mouse
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //criar caneta
        private Pen canetacor(Color cor, int esp)
        {
            Pen caneta = new Pen(cor, esp);
            caneta.DashPattern = tipolinha;
            return caneta;
        }

        //desenhar linha 
        bool testeforma = false;
        bool testeesp = false;

        private void retabres(Pen caneta, int x, int y, int xf, int yf, PaintEventArgs v)
        {
            v.Graphics.DrawLine(caneta, x, y, xf, yf);
        }

        bool a = true;
        bool executar;

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

           // retabres(canetacor(Color.Black, 46), 100, 400, 100, 200, e);
            //e.Graphics.DrawEllipse(canetacor(Color.Black,5),100,100,200,200);
            if (executar == true)
            {
                if (forma == 1)
                {
                    retabres(canetacor(cor, esp), corx, cory, corxf, coryf, e);
                    executar = false;
                } else if (forma == 4)
                {
                    retabres(canetacor(cor, esp), corx, cory, corxf, coryf, e);
                    retabres(canetacor(cor, esp), corxf, coryf, corx3, cory3, e);
                    retabres(canetacor(cor, esp), corx, cory, corx3, cory3, e);
                    
                    executar = false;
                } else if (forma == 2)
                {
                    retangulo(corx, cory,coryf,corxf, e);
                    executar = false;
                }
                else if (forma == 3)
                {
                    retabres(canetacor(cor, esp), corx, cory, corxf, coryf, e);
                    retabres(canetacor(cor, esp), corxf, coryf, corx3, cory3, e);
                    retabres(canetacor(cor, esp), corx3, cory3, corx4, cory4, e);
                    retabres(canetacor(cor, esp), corx4, cory4, corx, cory, e);
              
                    Point[] pontos = new Point[4];
                    pontos[0] = new Point(corx, cory);
                    pontos[1] = new Point(corxf, coryf);
                    pontos[2] = new Point(corx3, cory3);
                    pontos[3] = new Point(corx4, cory4);
                    e.Graphics.FillPolygon(pintar, pontos);
                    
                    executar = false;
                }
                else if (forma == 5)
                {
                    retabres(canetacor(cor, esp), corx, cory, corxf, coryf, e);
                    retabres(canetacor(cor, esp), corxf, coryf, corx3, cory3, e);
                    retabres(canetacor(cor, esp), corx3, cory3, corx4, cory4, e);
                    retabres(canetacor(cor, esp), corx4, cory4, corx5, cory5, e);
                    retabres(canetacor(cor, esp), corx5, cory5, corx, cory, e);
                    Point[] pontos = new Point[5];
                    pontos[0] = new Point(corx, cory);
                    pontos[1] = new Point(corxf, coryf);
                    pontos[2] = new Point(corx3, cory3);
                    pontos[3] = new Point(corx4, cory4);
                    pontos[4] = new Point(corx5, cory5);
                    e.Graphics.FillPolygon(pintar, pontos);
                    executar = false;

                }
                else if (forma == 6)
                {
                    //desenhaellipse(e, corx, cory,corxf,coryf);
                    desenhaellipse(e,corx, cory, (corxf > corx) ? corxf - corx : corx - corxf, (coryf > cory) ? coryf - cory : cory - coryf);
                }
            }

        }
        SolidBrush pintar = new SolidBrush(Color.Black);
        private void desenhaellipse(PaintEventArgs e,int x,int y,int xr,int yr)
        {

           e.Graphics.DrawEllipse(canetacor(cor,esp),x-xr,y-yr,xr*2,yr*2);
           e.Graphics.FillEllipse(pintar, x - xr, y - yr, xr * 2, yr * 2);

        }

        private void salvar(int forma,Color cor, int esp,float[] tipolinha,int corx,int cory,int corxf,int coryf,int corx3,int cory3,int corx4,int cory4,int corx5,int cory5)
        {
            StreamWriter x;
            string CaminhoNome = @"C:\Users\yanue\Documents\arq01.txt";
            x = File.CreateText(CaminhoNome);
            x.WriteLine(forma);
            x.WriteLine(cor);
            x.WriteLine(esp);
            x.WriteLine(tipolinha);
            x.WriteLine(corx);
            x.WriteLine(cory);
            x.WriteLine(corxf);
            x.WriteLine(coryf);
            x.WriteLine(corx3);
            x.WriteLine(cory3);
            x.WriteLine(corx4);
            x.WriteLine(cory4);
            x.WriteLine(corx5);
            x.WriteLine(cory5);
            x.WriteLine("====");
            x.Close();
            MessageBox.Show("salvo");


        }
        //CLICAR PARA DEFINIR X e Y
        int corx, cory, corxf, coryf,corx3, cory3,corx4,cory4,corx5,cory5;
        bool verificar_click = false;
        int verificar_click_tri = 0;

           private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (forma == 1)
            {
                if (!verificar_click)
                {
                    corx = e.X;
                    cory = e.Y;
                    verificar_click = true;
                }
                else
                {
                    corxf = e.X;
                    coryf = e.Y;
                    verificar_click = false;
                    executar = true;
                    panel2.Invalidate();
                }
            }
            else if (forma == 4)
            {
                if (verificar_click_tri == 0)
                {
                    corx = e.X;
                    cory = e.Y;
                    verificar_click_tri = 1;
                }
                else if (verificar_click_tri == 1)
                {
                    corxf = e.X;
                    coryf = e.Y;
                    verificar_click_tri = 2;
                }
                else
                {
                    corx3 = e.X;
                    cory3 = e.Y;
                    verificar_click_tri = 0;
                    executar = true;
                    panel2.Invalidate();
                }


            }
            else if (forma == 2)
            {
                if (verificar_click_tri == 0)
                {
                    corx = e.X;
                    cory = e.Y;
                    verificar_click_tri = 1;
                }
                else if (verificar_click_tri == 1) 
                {
                    corxf = e.X;
                    coryf = e.Y;
                    verificar_click_tri = 0;
                    executar = true;
                    panel2.Invalidate();
                }
            }
            else if (forma == 3)
            {
                if (verificar_click_tri == 0)
                {
                    corx = e.X;
                    cory = e.Y;
                    verificar_click_tri = 1;
                }
                else if (verificar_click_tri == 1)
                {
                    corxf = e.X;
                    coryf = e.Y;
                    verificar_click_tri = 2;
                }
                else if (verificar_click_tri == 2)
                {
                    corx3 = e.X;
                    cory3 = e.Y;
                    verificar_click_tri = 3;
                }
                else if (verificar_click_tri == 3)
                {

                    corx4 = e.X;
                    cory4 = e.Y;
                    verificar_click_tri = 0;
                    executar = true;
                    panel2.Invalidate();
                }
            }else if (forma == 5)
            {
                if (verificar_click_tri == 0)
                {
                    corx = e.X;
                    cory = e.Y;
                    verificar_click_tri = 1;
                }
                else if (verificar_click_tri == 1)
                {
                    corxf = e.X;
                    coryf = e.Y;
                    verificar_click_tri = 2;
                }
                else if (verificar_click_tri == 2)
                {
                    corx3 = e.X;
                    cory3 = e.Y;
                    verificar_click_tri = 3;
                   
                }
                else if (verificar_click_tri == 3)
                {
                    corx4 = e.X;
                    cory4 = e.Y;
                    verificar_click_tri = 4;
                }
                else if (verificar_click_tri == 4)
                {
                    corx5 = e.X;
                    cory5 = e.Y;
                    verificar_click_tri = 0;
                    executar = true;
                    panel2.Invalidate();
                }

            }
            else if (forma == 6)
            {
                if (verificar_click_tri == 0)
                {
                    corx = e.X;
                    cory = e.Y;
                    verificar_click_tri = 1;
                }
                else if (verificar_click_tri == 1)
                {
                    corxf = e.X;
                    coryf = e.Y;
                    verificar_click_tri = 0;
                    executar = true;
                    panel2.Invalidate();
                }
            }
        }




        //definindo a forma ///////////////////////////////////////////////////////////////////////
        int forma;
        private void cmdreta_Click(object sender, EventArgs e)
        {
            forma = 1;
            testeforma = true;
            a = false;
        }
        private void cmdquadrado_Click(object sender, EventArgs e)
        {
            forma = 2;
            testeforma = true;

        }
        private void cmdlosangulo_Click(object sender, EventArgs e)
        {
            forma = 3;
            testeforma = true;
        }

        private void cmdtriangulo_Click(object sender, EventArgs e)
        {
            forma = 4;
            testeforma = true;
        }

        private void cmdpentagono_Click(object sender, EventArgs e)
        {
            forma = 5;
            testeforma = true;
        }
        private void cmdelipse_Click(object sender, EventArgs e)
        {
            forma = 6;
                testeforma = true;
        }
        //selecao de cores////////////////////////////////////////////////////////////////////////
        private Color Cor(int r, int  g,int b)
        {
           Color corr = Color.FromArgb(r,g,b);
           return corr;
        }
        private void corlinha(object sender, EventArgs e)
        {
            Button cmd = sender as Button;
            if (opccor == true)
            {
                cmdcor1.BackColor = Cor(cmd.BackColor.R, cmd.BackColor.G, cmd.BackColor.B);
                cor = cmdcor1.BackColor;
            }
            else
            {
                cmdcor2.BackColor = Cor(cmd.BackColor.R, cmd.BackColor.G, cmd.BackColor.B);
                corpre = cmdcor2.BackColor;
                pintar.Color = cmdcor2.BackColor;
            }
        }
        
        Color cor, corpre;
        
        bool opccor;
       
        private void Cmdcor1_Click(object sender, EventArgs e)
        {
            opccor = true;
        }

        private void Cmdcor2_Click(object sender, EventArgs e)
        {
            opccor = false;
        }

        //grossura/////////////////////////////////////////////
        int esp;
        private void cmdgrossura1_Click(object sender, EventArgs e)
        {
            esp = 10;
            testeesp = true;
        }

        private void cmdgrossura2_Click(object sender, EventArgs e)
        {
            esp = 13;
            testeesp = true;
        }

        private void cmdgrossura3_Click(object sender, EventArgs e)
        {
            esp = 18;
            testeesp = true;
        }

        private void cmdgrossura5_Click(object sender, EventArgs e)
        {
            esp = 23;
            testeesp = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmdcor2.BackColor = Color.Black;
            corpre = cmdcor1.BackColor;
            cor = cmdcor2.BackColor;
            float[] aux = {1};
            tipolinha = aux;
        }

        private void retangulo(int x, int y, int yf, int xf,PaintEventArgs e)
        {
            int lar = 0;
            int al = 0;
            int px = 0;
            int py = 0;
            if (x < xf)
            {
                lar = xf - x;
                px = x;
            }
            else
            {
                lar = x - xf;
                px = xf;
            }

            if (y < yf)
            {
                al = yf - y;
                py = y;
            }
            else
            {
                al = y - yf;
                py = yf;
            }
            e.Graphics.DrawRectangle(canetacor(cor,esp),px, py, lar, al);

            e.Graphics.FillRectangle(pintar, px, py, lar, al);
        }



        ///////// TIPO DE LINHA
        float[] tipolinha;
        private void cmdtipolinha1_Click(object sender, EventArgs e)
        {
            float[] solid = {1};
            tipolinha = solid;
        }

        private void cmdtipolinha2_Click(object sender, EventArgs e)
        {

           float[] dash = {5,1};
           tipolinha = dash;
        }
        private void cmdtipolinha3_Click(object sender, EventArgs e)
        {
            float[] dot = { 2, 2 };
            tipolinha = dot;
        }

        private void cmdtipolinha4_Click(object sender, EventArgs e)
        {
            float[] dashdot = {5,2,1,2};
            tipolinha = dashdot;
        }

        private void cmdtipolinha5_Click(object sender, EventArgs e)
        {

            float[] dashdotdot = {5,2,1,2,1,2};
                tipolinha = dashdotdot;
        }
        
        
        ////// ESCALA
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (forma == 1)
            {
                
            }
            else if (forma == 4)
            {

                panel2.Invalidate();
            }
            else if (forma == 2)
            {
                panel2.Invalidate();
            }
            else if (forma == 3)
            {

                panel2.Invalidate();
            }
            else if (forma == 5)
            {

                panel2.Invalidate();
            }
            else if (forma == 6)
            {
                
                panel2.Invalidate();
            }
        }

        private void cmdsalvar_Click(object sender, EventArgs e)
        {
            salvar(forma,cor,esp,tipolinha,corx,cory,corxf,coryf,corx3,cory3,corx4,cory4,corx5,cory5);
        }

     

       

       


        
    }
}
