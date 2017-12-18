#include "Stdafx.h"
#include "PIN.h"

namespace ELM_GUI_lib {

	const std::string PIN::LENGTH = "short";

	PIN::PIN() {
	}

	PIN::PIN(std::string d_name, double d_x, double d_y) {
		name = d_name;
		loc_x = d_x;
		loc_y = d_y;

		XMLtext = "<pin name=\"";
		XMLtext.append(name);

		XMLtext.append("\" x=\"");
		XMLtext.append(XMLParse::numToString(loc_x));

		XMLtext.append("\" y=\"");
		XMLtext.append(XMLParse::numToString(loc_y));

		XMLtext.append("\" length=\"");
		XMLtext.append(PIN::LENGTH);

		XMLtext.append("\" rot=\"R90\"/>\n");

		//<pin name="PGM/LVP" x="17.78" y="2.54" length="short"/>
	}

	PIN::PIN(const PIN& orig) {
	}

	PIN::~PIN() {
	}

}