#include "Stdafx.h"
#include "XMLParse.h"

namespace ELM_GUI_lib {

	XMLParse::XMLParse() {
	}

	XMLParse::XMLParse(const XMLParse& orig) {
	}

	XMLParse::~XMLParse() {
	}

	std::string XMLParse::generateTag(XML_TAGS TAG, std::string param) {

		std::string intermediate = "";
		std::string out = "";

		switch (TAG) {

		case CONNECTS_START: {
			out = "<connects>";
			break;
		}
		case CONNECT: {
			intermediate = "<connect gate=\"G$1\" pin=\"";
			intermediate.append(param);
			intermediate.append("\" pad=\"");
			intermediate.append(param);
			out = intermediate.append("\"/>");
			break;
		}
		case CONNECTS_END: {
			out = "</connects>";
			break;
		}

		case GENERIC_VALUE_SYMBOL: {
			out = "<text x=\"0\" y=\"0.5\" size=\"0.05\" layer=\"96\">&gt;VALUE</text>";
			break;
		}
		case GENERIC_NAME_SYMBOL: {
			out = "<text x=\"0\" y=\"0\" size=\"0.05\" layer=\"95\">&gt;NAME</text>";
			break;
		}

		case GENERIC_NAME_PACKAGE: {
			out = "<text x=\"0\" y=\"0\" size=\"0.10\" layer=\"25\">&gt;NAME</text>";
			break;
		}

		case TECHNOLOGIES_START: {
			out = "<technologies>";
			break;
		}
		case TECHNOLOGIES_END: {
			out = "</technologies>";
			break;
		}
		case TECHNOLOGY: {
			out = "<technology name=\"\"/>";
			break;
		}

		case DEVICE_START: {

			if (param.compare("") != 0) {
				intermediate = "<device name=\"\" package=\"";
				intermediate.append(param);
				out = intermediate.append("\">");
				break;
				//<device name="" package="SPDT_1210TB">
			}
			else {
				out = "<device name=\"\">";
				break;
				//<device name="">
			}
		}
		case DEVICE_END: {
			out = "</device>";
			break;
		}

		case DEVICES_START: {
			out = "<devices>";
			break;
		}
		case DEVICES_END: {
			out = "</devices>";
			break;
		}

		case GATES_START: {
			out = "<gates>";
			break;
		}
		case GATE: {
			intermediate = "<gate name=\"G$1\" symbol=\"";
			intermediate.append(param);
			out = intermediate.append("\" x=\"0\" y=\"0\"/>");
			break;
		}
		case GATES_END: {
			out = "</gates>";
			break;
		}

		case DEVICESET_START: {
			intermediate.append("<deviceset name=\"");
			intermediate.append(param);
			out = intermediate.append("\" uservalue=\"yes\">");
			break;
		}
		case DEVICESET_END: {
			out = "</deviceset>";
			break;
		}

		case DEVICESETS_START: {
			out = "<devicesets>";
			break;
		}
		case DEVICESETS_END: {
			out = "</devicesets>";
			break;
		}

		case SYMBOL_START: {
			intermediate.append("<symbol name=\"");
			intermediate.append(param);
			out = intermediate.append("\">");
			break;
		}
		case SYMBOL_END: {
			out = "</symbol>";
			break;
		}

		case PACKAGE_START: {
			intermediate.append("<package name=\"");
			intermediate.append(param);
			out = intermediate.append("\">");
			break;
		}
		case PACKAGE_END: {
			out = "</package>";
			break;
		}

		case PACKAGES_START: {
			out = "<packages>";
			break;
		}
		case PACKAGES_END: {
			out = "</packages>";
			break;
		}
		}
		return out.append("\n");
	}

	std::string XMLParse::tagWrapXML(std::string XML_in, std::string start, std::string end) {

		//Automatically adds \n after <start> and before <end>.
		std::string cr = "\n";

		start = start.append(cr);
		end = end.append(cr);
		std::string XML_out = start.append(XML_in);
		return XML_out.append(end);
	}
	std::string XMLParse::nameFromXML(std::string XML_in) {

		//Can replace with higher-level operation getAttribute.

		//We can take substring(indexofFirst("), indexofLast("))
		int firstquote_ind = XML_in.find("\"", 0, 1);
		int secondquote_ind = XML_in.find("\"", firstquote_ind + 1, 1);

		std::string deviceName1 = XML_in.substr(firstquote_ind + 1);
		std::string deviceName2 = XML_in.substr(secondquote_ind);

		std::string deviceName = deviceName1.substr(0, deviceName1.find(deviceName2));

		return deviceName;
	}

	std::string XMLParse::numToString(double x) {
		char * tempNum = new char[20];
		sprintf(tempNum, "%.10lf", x);
		std::string out = tempNum;
		return out;
	}
	std::string XMLParse::numToString(int x) {
		char * tempNum = new char[20];
		sprintf(tempNum, "%d", x);
		std::string out = tempNum;
		return out;
	}
}