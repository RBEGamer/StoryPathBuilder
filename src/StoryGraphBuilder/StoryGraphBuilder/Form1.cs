﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Net;
using System.IO;


namespace StoryGraphBuilder
{
    public partial class Form1 : Form
    {

        Graphics grafics;
        Image render_img;
        Panel render_panel;

        node node_to_set = null;


        public Form1()
        {
            InitializeComponent();
          
            render_panel = panel2;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
  

        }

        //ADD TEXT
        private void button1_Click(object sender, EventArgs e)
        {
           
            node n = new text_node();
            (n as text_node).generate_propery_plane();
            node_to_set = n;
        }
        //ADD OPTION
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //REMOVE NODE
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void panel2_Click(object sender, EventArgs e)
        {
          //DRAW A BOX
            if (node_to_set != null)
            {
                node_to_set.pos_x = render_panel.PointToClient(Cursor.Position).X;
                node_to_set.pos_y = render_panel.PointToClient(Cursor.Position).Y;

                switch (node_to_set.GetType().Name)
                {
                    case "node": break;
                    case "text_node": (node_to_set as text_node).generate_propery_plane(); break;
                    case "option_node": (node_to_set as option_node).generate_propery_plane(); break;
                    default: break;
                }

                
                render_panel.Controls.Add(node_to_set.render_panel);

                node_to_set = null;
            }
        }
    }
}
