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
    public class node
    {
        public long id; //unique node id
        private Graphics g; //grafics ref for rendering
        public Point anchor; //draw pivot
        public Size node_size; //size of the node panel
        public Rectangle draw_in_rect; //needed for clipping
        protected Panel node_panel; //node panel
        public Bitmap node_bitmap_to_display; //image of the node panel
        public bool has_panel_changed = true; //drw need update
        public Panel property_panel; //panel for settings

        //BASIC CONST TO SET IMPORTANT VARS LIKE ID POS SIZE
        public node(long _id,ref Graphics _g, Point _anchor, Rectangle _draw_in_rect)
        {
            id = _id;
            anchor = _anchor;
            if(anchor.X < 0 || anchor.Y < 0) { anchor = new Point(0, 0); }
            g = _g;
            draw_in_rect = _draw_in_rect;
              //SETUP PANEL
              node_panel = new Panel();
            node_size = node_panel.Size;
            node_panel.BackColor = Color.Red;
        }
        //CREATES A BITMAP OF THE NODE
        public Bitmap create_node_bitmap()
        {
            if (has_panel_changed)
            {
                node_bitmap_to_display = new Bitmap(node_panel.Size.Width, node_panel.Size.Height);
                node_panel.DrawToBitmap(node_bitmap_to_display, new Rectangle(0, 0, node_panel.Width, node_panel.Height));
                node_size = node_panel.Size;
                has_panel_changed = false;
            }
            return node_bitmap_to_display;
        }
        //IF NODE IS DISPLAY SPACE (CLIPPING) CREATE A BITMAP AND RENDERT IT TO THE GRAFICS REF
        public void draw_to_graphics(ref Graphics _g)
        {
            //simple clipping
            if (draw_in_rect.IntersectsWith(new Rectangle(anchor, node_panel.Size))){
                return;
            }
            _g.DrawImage(create_node_bitmap(), anchor);
        }

        //is ein punkt im node _rp is a click point in the drwing rect!!!!!!!! use rect2client or clac self
        public bool intersects_with_node(Point _p)
        {
           return _p.X > anchor.X & _p.Y > anchor.Y & _p.X < anchor.X+node_panel.Size.Width & _p.Y < anchor.Y+node_panel.Size.Height;
        }


        public void mouse_click(Point _p)
        {
            //IS CLICK IN NODE
            if (intersects_with_node(_p))
            {
                Console.WriteLine("mouse_click on " + id.ToString());
                //TODO SHOW PARAMETER PANEL
            }
        }



        public String toString()
        {
            return "node id:" + id.ToString() + " anchor:" + anchor.ToString();
        }


        //EDIT THIS FOR EVERY NODE -----------------------

        public void generate_node_panel()
        {
            node_panel.Location = anchor;
            has_panel_changed = true;
        }

        public void generate_prperty_panel()
        {
           
            has_panel_changed = true;
        }
    }


    public class text_node : node
    {

        protected const int text_bumbruch_zeichen_line = 40;
        protected const int con_box_size = 10;
        public String headline_text = "---";
        public String message_text = "---";
        Panel con_box_out;
        Panel seperation_line_message;
        Label message_text_l;
        Panel seperation_line_head_1;
        Label headline = new Label();
        Panel seperation_line_head_0;
        Panel con_box_in;


        public text_node(long _id, ref Graphics _g, Point _anchor, Rectangle _draw_in_rect) : base( _id, ref  _g,  _anchor,  _draw_in_rect)
        {
            
            headline_text = "-TEXTNODE-";
            message_text = "---";

            node_panel.BackColor = Color.Red;
            generate_node_panel();
            generate_prperty_panel();

            con_box_out = new Panel();
            seperation_line_message = new Panel();
            message_text_l = new Label();
            seperation_line_head_1 = new Panel();
            headline = new Label();
            seperation_line_head_0 = new Panel();
            con_box_in = new Panel();
        }


        public void generate_node_panel()
        {
            int size_h = 0;
            int size_w = 200;
             //CREATE PANEL BOX
            node_panel.Controls.Clear();
            node_panel.Location = anchor;
            node_panel.Size = new Size(size_w, size_h);
            node_panel.BackColor = Color.PaleVioletRed;
           // node_panel.MouseDown += on_down_plane;
           // node_panel.MouseUp += on_up_plane;
            //node_panel.MouseMove += on_move_plane;
            //CREATE BUBBLE INPUT
            if(con_box_in == null) { con_box_in = new Panel(); }
            con_box_in.Size = new Size(con_box_size, con_box_size);
            con_box_in.Location = new Point((int)(size_w / 2f), size_h);
            con_box_in.BackColor = Color.Red;
            size_h += con_box_size;
            node_panel.Controls.Add(con_box_in);
            //TODO REGISTER CLICK EVENT
            //CREATE LINE
            {
                size_h += 2;
                if (seperation_line_head_0 == null) { seperation_line_head_0 = new Panel(); }
                seperation_line_head_0.Location = new Point(0, size_h);
                seperation_line_head_0.Size = new Size(size_w, 2);
                seperation_line_head_0.BackColor = Color.Black;
                node_panel.Controls.Add(seperation_line_head_0);
                size_h += 5;
            }
            //CREATE HEADLINE BOX
            headline.Text = headline_text;
            headline.TextAlign = ContentAlignment.MiddleCenter;
            int hl_w = (int)(headline_text.Length * 12);
            int hl_h = (int)((headline.Font.SizeInPoints * 2f) * (1 + headline_text.Length / text_bumbruch_zeichen_line));
            if (hl_w > size_w) { hl_w = size_w; }
            headline.Size = new Size(hl_w, hl_h);
            headline.Location = new Point(0, size_h); //offset from box
            size_h += hl_h; //increase box size
            headline.Enabled = true;
            node_panel.Controls.Add(headline);
            //CREATE LINE
            {
                size_h += 2;
                if (seperation_line_head_1 == null) { seperation_line_head_1 = new Panel(); }
                seperation_line_head_1.Location = new Point(0, size_h);
                seperation_line_head_1.Size = new Size(size_w, 2);
                seperation_line_head_1.BackColor = Color.Black;
                node_panel.Controls.Add(seperation_line_head_1);
                size_h += 5;
            }
            //CREATE TEXT BOX
            if (message_text_l == null) { message_text_l = new Label(); }
            message_text_l.Text = message_text;
            int me_w = (int)(message_text.Length * 12);
            int me_h = (int)((message_text_l.Font.SizeInPoints * 2f) * (1 + message_text.Length / text_bumbruch_zeichen_line));
            if (me_w > size_w) { me_w = size_w; }
            message_text_l.Size = new Size(me_w, me_h);
            message_text_l.Location = new Point(0, size_h); //offset from box
            size_h += me_h; //increase box size
            message_text_l.Enabled = true;
            node_panel.Controls.Add(message_text_l);
            //CREATE LINE
            {
                size_h += 2;
                if (seperation_line_message == null) { seperation_line_message = new Panel(); }
                seperation_line_message.Location = new Point(0, size_h);
                seperation_line_message.Size = new Size(size_w, 2);
                seperation_line_message.BackColor = Color.Black;
                node_panel.Controls.Add(seperation_line_message);
                size_h += 5;
            }

            //CREATE BUBBLE INPUT
            if (con_box_out == null) { con_box_out = new Panel(); }
            con_box_out.Size = new Size(con_box_size, con_box_size);
            con_box_out.Location = new Point((int)(size_w / 2f), size_h);
            con_box_out.BackColor = Color.Green;
            size_h += con_box_size;
            node_panel.Controls.Add(con_box_out);
            //TODO REGISTER CLICK EVENT
            //ADJUST THE PANEL SIZE IMPORTANT FOR CORRECT DISPLAYING!
            node_panel.Size = new Size(size_w, size_h);
            node_panel.Location = anchor;
            has_panel_changed = true;
        }

        public void generate_prperty_panel()
        {
    //TODO ADD
            has_panel_changed = true;
        }




    }



    }
