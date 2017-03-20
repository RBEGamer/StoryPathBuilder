using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StoryGraphBuilder
{

  
    public class node
    {

        public int pos_x, pos_y;
        public UInt32 id;
        public String node_name;
        public Panel render_panel;
        public String headline_text = "---";
        public String message_text = "---";


       

        protected int con_box_size = 10;
        protected int text_bumbruch_zeichen_line = 30; //new line >30 chars

        /*---------------------------------------------------*/
        public  node()
        {
            render_panel = new Panel();
            headline_text = "-NODE-";
            message_text = "---";
        }


    }




    public class text_node : node
    {

        const int text_bumbruch_zeichen_line = 40;
        const int con_box_size = 10;

        Panel con_box_out;
        Panel seperation_line_message;
        Label message_text_l;
        Panel seperation_line_head_1;
        Label headline = new Label();
        Panel seperation_line_head_0;
        Panel con_box_in;

        public  text_node()
        {
            render_panel = new Panel();
            headline_text = "-TEXTNODE-";
            message_text = "---";

             con_box_out = new Panel();
             seperation_line_message = new Panel();
             message_text_l = new Label();
             seperation_line_head_1 = new Panel();
             headline = new Label();
             seperation_line_head_0 = new Panel();
             con_box_in = new Panel();
        }

        public  void generate_propery_plane()
        {

            int size_w = 200;
            int size_h = 0;

            //CREATE PANEL BOX
            render_panel.Controls.Clear();
            render_panel.Location = new Point(pos_x, pos_y);
            render_panel.Size = new Size(size_w, size_h);
            render_panel.BackColor = Color.PaleVioletRed;
            //CREATE BUBBLE INPUT
            con_box_in.Size = new Size(con_box_size, con_box_size);
            con_box_in.Location = new Point((int)(size_w / 2f), size_h);
            con_box_in.BackColor = Color.Red;
            size_h += con_box_size;
            render_panel.Controls.Add(con_box_in);
            //TODO REGISTER CLICK EVENT
            //CREATE LINE
            {
                size_h += 2;

                seperation_line_head_0.Location = new Point(0, size_h);
                seperation_line_head_0.Size = new Size(size_w, 2);
                seperation_line_head_0.BackColor = Color.Black;
                render_panel.Controls.Add(seperation_line_head_0);
                size_h += 5;
            }

            //CREATE HEADLINE BOX

            headline.Text = headline_text;
            int hl_w = (int)(headline_text.Length * 12);
            int hl_h = (int)((headline.Font.SizeInPoints * 2f) * (1 + headline_text.Length / text_bumbruch_zeichen_line));
            if (hl_w > size_w) { hl_w = size_w; }
            headline.Size = new Size(hl_w, hl_h);
            headline.Location = new Point(0, size_h); //offset from box
            size_h += hl_h; //increase box size
            headline.Enabled = true;
            render_panel.Controls.Add(headline);

            //CREATE LINE
            {
                size_h += 2;

                seperation_line_head_1.Location = new Point(0, size_h);
                seperation_line_head_1.Size = new Size(size_w, 2);
                seperation_line_head_1.BackColor = Color.Black;
                render_panel.Controls.Add(seperation_line_head_1);
                size_h += 5;
            }


            //CREATE TEXT BOX

            message_text_l.Text = message_text;
            int me_w = (int)(message_text.Length * 12);
            int me_h = (int)((message_text_l.Font.SizeInPoints * 2f) * (1 + message_text.Length / text_bumbruch_zeichen_line));
            if (me_w > size_w) { me_w = size_w; }
            message_text_l.Size = new Size(me_w, me_h);
            message_text_l.Location = new Point(0, size_h); //offset from box
            size_h += me_h; //increase box size
            message_text_l.Enabled = true;
            render_panel.Controls.Add(message_text_l);



            //CREATE LINE
            {
                size_h += 2;

                seperation_line_message.Location = new Point(0, size_h);
                seperation_line_message.Size = new Size(size_w, 2);
                seperation_line_message.BackColor = Color.Black;
                render_panel.Controls.Add(seperation_line_message);
                size_h += 5;
            }

            //CREATE BUBBLE INPUT

            con_box_out.Size = new Size(con_box_size, con_box_size);
            con_box_out.Location = new Point((int)(size_w / 2f), size_h);
            con_box_out.BackColor = Color.Green;
            size_h += con_box_size;
            render_panel.Controls.Add(con_box_out);
            //TODO REGISTER CLICK EVENT


            //ADJUST THE PANEL SIZE
            render_panel.Size = new Size(size_w, size_h);
        }

        public  void draw_node()
        {

        }
    }



    public class option_node : node
    {

        Panel con_box_out;
        Panel seperation_line_message;
        Panel seperation_line_head_1;
        Label headline = new Label();
        Panel seperation_line_head_0;
        Panel con_box_in = new Panel();


        public option_node()
        {
            render_panel = new Panel();
            headline_text = "-OPTIONNODE-";
            message_text = "---";

             con_box_out = new Panel();
             seperation_line_message = new Panel();
             seperation_line_head_1 = new Panel();
             headline = new Label();
             seperation_line_head_0 = new Panel();
             con_box_in = new Panel();

        }

        public void generate_propery_plane()
        {

            int size_w = 200;
            int size_h = 0;
            
            //CREATE PANEL BOX
            render_panel.Controls.Clear();
            render_panel.Location = new Point(pos_x, pos_y);
            render_panel.Size = new Size(size_w, size_h);
            render_panel.BackColor = Color.LightGoldenrodYellow;
            //CREATE BUBBLE INPUT
            
            con_box_in.Size = new Size(con_box_size, con_box_size);
            con_box_in.Location = new Point((int)(size_w / 2f), size_h);
            con_box_in.BackColor = Color.Red;
            size_h += con_box_size;
            render_panel.Controls.Add(con_box_in);
            //TODO REGISTER CLICK EVENT
            //CREATE LINE
           
                size_h += 2;

                seperation_line_head_0.Location = new Point(0, size_h);
                seperation_line_head_0.Size = new Size(size_w, 2);
                seperation_line_head_0.BackColor = Color.Black;
                render_panel.Controls.Add(seperation_line_head_0);
                size_h += 5;
         

            //CREATE HEADLINE BOX

            headline.Text = headline_text;
            int hl_w = (int)(headline_text.Length * 12);
            int hl_h = (int)((headline.Font.SizeInPoints * 2f) * (1 + headline_text.Length / text_bumbruch_zeichen_line));
            if (hl_w > size_w) { hl_w = size_w; }
            headline.Size = new Size(hl_w, hl_h);
            headline.Location = new Point(0, size_h); //offset from box
            size_h += hl_h; //increase box size
            headline.Enabled = true;
            render_panel.Controls.Add(headline);

            //CREATE LINE
         
                size_h += 2;
                seperation_line_head_1.Location = new Point(0, size_h);
                seperation_line_head_1.Size = new Size(size_w, 2);
                seperation_line_head_1.BackColor = Color.Black;
                render_panel.Controls.Add(seperation_line_head_1);
                size_h += 5;
            
            //CREATE LINE
        
                size_h += 2;
                seperation_line_message.Location = new Point(0, size_h);
                seperation_line_message.Size = new Size(size_w, 2);
                seperation_line_message.BackColor = Color.Black;
                render_panel.Controls.Add(seperation_line_message);
                size_h += 5;
            

            //CREATE BUBBLE INPUT

            con_box_out.Size = new Size(con_box_size, con_box_size);
            con_box_out.Location = new Point((int)(size_w / 2f), size_h);
            con_box_out.BackColor = Color.Green;
            size_h += con_box_size;
            render_panel.Controls.Add(con_box_out);
            //TODO REGISTER CLICK EVENT


            //ADJUST THE PANEL SIZE
            render_panel.Size = new Size(size_w, size_h);
        }

        public void draw_node()
        {

        }
    }
}
