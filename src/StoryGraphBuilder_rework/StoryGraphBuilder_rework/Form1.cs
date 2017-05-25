using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoryGraphBuilder_rework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        Graphics graphics;
        Bitmap drawing_bitmap;



        node t;
        String node_to_add_name = ""; //if not null this node will be added on th enext click
        public List<node> nodes_list = new List<node>();
        private long nodes_id_counter = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            nodes_id_counter = 0;

            drawing_bitmap = new Bitmap(main_display_pic_box.Width, main_display_pic_box.Height);
            graphics = Graphics.FromImage(drawing_bitmap);

            main_display_pic_box.Focus();
            
            //CLEAR
            graphics.FillRectangle(Brushes.DarkGray, 0, 0, drawing_bitmap.Width, drawing_bitmap.Height);
            main_display_pic_box.Image = drawing_bitmap;



            draw_g_to_pic_box();
        }


        public void draw_g_to_pic_box()
        {
            main_display_pic_box.Focus();
            graphics = Graphics.FromImage(drawing_bitmap);
            main_display_pic_box.Image = drawing_bitmap;


            for (int i = 0; i < nodes_list.Count; i++)
            {
               nodes_list[i].draw_to_graphics(ref graphics);
            }




        }
        //EVENT FÜR AUF EINE NODE CLICKEN
        private void main_display_pic_box_Click(object sender, EventArgs e)
        {
            //FIRSTCEHCK IF WE WANT TO ADD A NEW NODE
            //IF YES ADD THEM SIMPLY
            if (node_to_add_name != "")
            {
                switch (node_to_add_name)
                {
                    case "textnode":
                        nodes_list.Add(new text_node(nodes_id_counter++, ref graphics, main_display_pic_box.PointToClient(MousePosition), new Rectangle(main_display_pic_box.Location.X, main_display_pic_box.Location.Y, main_display_pic_box.Width, main_display_pic_box.Height)));
                        break;
                    default:
                        MessageBox.Show("Invalid node type");
                        break;
                }
                node_to_add_name = "";

            }
            else
            {
                //ELSE CALL IN EVERY NODE CLICK FUNC 
                for (int i = 0; i < nodes_list.Count; i++)
                {
                    nodes_list[i].mouse_click(main_display_pic_box.PointToClient(MousePosition));
                }
            }

            //LAST DRAW NODE
            draw_g_to_pic_box();
        }

        private void btn_add_text_node_Click(object sender, EventArgs e)
        {
            node_to_add_name = "textnode";
        }
    }
}
