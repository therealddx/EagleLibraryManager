#include "Stdafx.h"
#include "SMD.h"

namespace ELM_GUI_lib {

	SMD::SMD() {
		name = "";
		XMLtext = "";
	}

	SMD::SMD(std::string d_name, double d_center_x, double d_center_y, double d_dx, double d_dy, int d_layer) {

		name = d_name;
		center_x = d_center_x;
		center_y = d_center_y;
		dx = d_dx;
		dy = d_dy;
		layer = d_layer;

		XMLtext = "<smd name=\"";
		XMLtext.append(name);

		XMLtext.append("\" x=\"");
		XMLtext.append(XMLParse::numToString(center_x));

		XMLtext.append("\" y=\"");
		XMLtext.append(XMLParse::numToString(center_y));

		XMLtext.append("\" dx=\"");
		XMLtext.append(XMLParse::numToString(dx));

		XMLtext.append("\" dy=\"");
		XMLtext.append(XMLParse::numToString(dy));

		XMLtext.append("\" layer=\"");
		XMLtext.append(XMLParse::numToString(layer));

		XMLtext.append("\"/>\n");

		//Example:
		//<smd name="GND2" x="0" y="2.921" dx="1.778" dy="1.778" layer="1"/>

	}

	SMD::SMD(const SMD& orig) {
	}

	SMD::~SMD() {
	}

}