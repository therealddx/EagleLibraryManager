#include "Stdafx.h"

#ifndef SMD_H
#define SMD_H

#include <string>
#include <stdio.h>
#include "XMLParse.h"

namespace ELM_GUI_lib {

	public class SMD {
	public:

		SMD();
		SMD(std::string name, double center_x, double center_y, double dx, double dy, int layer);
		SMD(const SMD& orig);
		virtual ~SMD();

		std::string name;
		double center_x; //All linear dimensions in MILLIMETERS.
		double center_y;
		double dx;
		double dy;
		int layer; //Layer is either top or bottom... Either 1 or 16...
		std::string XMLtext;

		//Example:
		//<smd name="GND2" x="0" y="2.921" dx="1.778" dy="1.778" layer="1"/>

	private:

	};
}

#endif /* SMD_H */