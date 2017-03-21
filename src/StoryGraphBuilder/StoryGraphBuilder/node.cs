using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StoryGraphBuilder
{

  //FOR TEST THE MOST IS PUBLIC FOR THE XML EXPORT
    public class node
    {

        public int pos_x, pos_y;
        public UInt32 id;
        public String node_name;
        public Panel render_panel;
        public String headline_text = "---";
        public String message_text = "---";

        public Panel parameter_panel = null;
        public Panel display_panel = null;

        protected int con_box_size = 10;
        protected int text_bumbruch_zeichen_line = 5; //new line >30 chars

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

        public void set_param_panel(ref Panel _ref_panel)
        {
            parameter_panel = _ref_panel;
        }

       public  bool is_clicked = false;
        public Point click_point;
        public void on_down_plane(Object sender, EventArgs e)
        {
            is_clicked = true;
            click_point = render_panel.PointToClient(Cursor.Position);
        }
        public void on_up_plane(Object sender, EventArgs e)
        {
            is_clicked = false;
        }
        public void on_move_plane(Object sender, EventArgs e)
        {
          //TODO FIX
          //TODO add to render plane in node cs self and deleting self
          //TODO ID GENERATOR
            if (is_clicked)
            {
                if (display_panel == null) { return; }
                this.pos_x = display_panel.PointToClient(Cursor.Position).X - click_point.X +1;
                this.pos_y = display_panel.PointToClient(Cursor.Position).Y - click_point.Y +1;
                generate_propery_plane();
            }
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
            render_panel.MouseDown += on_down_plane;
            render_panel.MouseUp += on_up_plane;
            render_panel.MouseMove += on_move_plane;
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
            headline.TextAlign = ContentAlignment.MiddleCenter;
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

        public void param_click_save_btn(Object sender, EventArgs e)
        {
            parameter_panel.Controls.Clear();
        }
        public void param_message_box_change(Object sender, EventArgs e)
        {
            message_text = ((TextBox)sender).Text;
            generate_propery_plane();
          //  MessageBox.Show(message_text);
        }

        public void generate_param_panel()
        {
            if (parameter_panel == null) { return; }
            //height width fixed
            parameter_panel.Controls.Clear();
            int controls_abstand_w = 10;
            //HEADLINE LABEL
            Label headline_param_panel = new Label();
            headline_param_panel.TextAlign = ContentAlignment.MiddleCenter;
            headline_param_panel.Text = headline_text;
            headline_param_panel.Size = new Size(parameter_panel.Width - controls_abstand_w, (int)(headline_param_panel.Font.SizeInPoints *2));
            parameter_panel.Controls.Add(headline_param_panel);
            //ADD TEXTBOX FOR MESSAGE
            TextBox message_box_param_panel = new TextBox();
            message_box_param_panel.Multiline = true;
            message_box_param_panel.Text = message_text;
            message_box_param_panel.Location = new Point((int)(controls_abstand_w / 2.0f), parameter_panel.Size.Height-200 -40);
            message_box_param_panel.Size = new Size(parameter_panel.Width - controls_abstand_w, 200);
            message_box_param_panel.TextChanged += param_message_box_change;
            parameter_panel.Controls.Add(message_box_param_panel);
            //ADD SAVE BUTTON
            Button save_btn_param_panel = new Button();
            save_btn_param_panel.Size = new Size(parameter_panel.Size.Width - controls_abstand_w, 30);
            save_btn_param_panel.Location = new Point((int)(controls_abstand_w/2.0f), parameter_panel.Size.Height - save_btn_param_panel.Size.Height - 2);
            save_btn_param_panel.Text = "SAVE";
            save_btn_param_panel.MouseClick += param_click_save_btn; //register event handler
            parameter_panel.Controls.Add(save_btn_param_panel);
        }


        public  void draw_node()
        {

        }
    }





    public class option_node_options
    {

        public String _option_text;
        public option_node _ref_node;
        public option_node _ref_node_dest;
        public int dest_node_id;
        public option_node_options()
        {
            dest_node_id = -1;
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

        public void set_param_panel(ref Panel _ref_panel)
        {
            parameter_panel = _ref_panel;
        }


        public List<option_node_options> options = new List<option_node_options>();

        public void add_option(String _text)
        {
            if(_text == "") { return; }
            bool is_in = false;
            for (int i = 0; i < options.Count; i++)
            {
                if (options[i]._option_text == _text)
                {
                    return;
                }
            }
            option_node_options op_tmp = new option_node_options();
            op_tmp._option_text = _text;
            op_tmp._ref_node = this;
            options.Add(op_tmp);
        }

        public void remove_option(String _text) {
            if (_text == "") { return; }
            for (int i = 0; i < options.Count; i++)
            {
                if (options[i]._option_text == _text)
                {
                    options.RemoveAt(i);
                    return;
                }
            }

        }

        public option_node()
        {
            render_panel = new Panel();
            headline_text = "-OPTIONNODE-";
            message_text = "---";
            options.Clear();

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
            headline.TextAlign = ContentAlignment.MiddleCenter;
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
            

            //CREATE BUBBLE OUTPUT


            //for every node
            //add panel
            //max text width 10
            //add bubble
            //add bubble id

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
