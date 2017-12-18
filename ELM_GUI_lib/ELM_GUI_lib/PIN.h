#include "Stdafx.h"

#ifndef PIN_H
#define PIN_H

#include <string>
#include "XMLParse.h"

namespace ELM_GUI_lib {

	public class PIN {
	public:
		PIN();
		PIN(std::string d_name, double d_x, double d_y);
		PIN(const PIN& orig);
		virtual ~PIN();

		std::string name;
		double loc_x;
		double loc_y;
		static const std::string LENGTH; //forced to "short".
		std::string XMLtext;
		//rotation: ignored
		//direction: ignored

		//<pin name="PGM/LVP" x="17.78" y="2.54" length="short"/>

	private:

	};

}

#endif /* PIN_H */

