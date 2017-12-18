#include "Stdafx.h"

#ifndef SYMBOL_H
#define SYMBOL_H

#include <string>
#include <vector>
#include "XMLParse.h"
#include "PIN.h"

namespace ELM_GUI_lib {

	public class Symbol {
	public:
		Symbol();
		Symbol(std::string d_name);
		Symbol(std::string d_name, std::vector<std::string> padNames, int totalNumPads);

		Symbol(const Symbol& orig);
		virtual ~Symbol();

		std::string name;
		std::string XMLtext;

		int numPins;
		PIN* pins;
		double PINSPACE;

	private:

	};
}

#endif /* SYMBOL_H */