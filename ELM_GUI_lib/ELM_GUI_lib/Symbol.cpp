#include "Stdafx.h"
#include "Symbol.h"

namespace ELM_GUI_lib {

	Symbol::Symbol() {
		name = "";
		XMLtext = "";
	}

	Symbol::Symbol(std::string d_name) {
		name = d_name;
		XMLtext = XMLParse::generateTag(XMLParse::XML_TAGS::SYMBOL_START, name);
		XMLtext.append(XMLParse::generateTag(XMLParse::GENERIC_NAME_SYMBOL));
		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::SYMBOL_END));
	}

	Symbol::Symbol(std::string d_name, std::vector<std::string> padNames, int totalNumPads) {

		PINSPACE = 12.7/2;

		name = d_name;
		numPins = totalNumPads;
		pins = new PIN[numPins];
		
		//Filling out the pin array.
		//names must have num elements == N_x * N_y, yes.
		double cur_loc_x = 0;
		for (int n = 0; n < numPins; n++) {
			PIN pin(padNames[n], cur_loc_x, 0);
			pins[n] = pin;
			cur_loc_x += PINSPACE;
		}

		XMLtext = XMLParse::generateTag(XMLParse::SYMBOL_START, name);
		for (int n = 0; n < numPins; n++) {
			XMLtext.append(pins[n].XMLtext);
		}
		XMLtext.append(XMLParse::generateTag(XMLParse::GENERIC_NAME_SYMBOL));
		XMLtext.append(XMLParse::generateTag(XMLParse::GENERIC_VALUE_SYMBOL));
		XMLtext.append(XMLParse::generateTag(XMLParse::SYMBOL_END));
		
	}

	Symbol::Symbol(const Symbol& orig) {
	}

	Symbol::~Symbol() {
	}
}