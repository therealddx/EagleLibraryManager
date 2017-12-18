#include "Stdafx.h"
#include "ELM.h"
#include "ctype.h"

namespace ELM_GUI_lib {

	//Declare constructors.
	ELM::ELM() {
	}

	ELM::ELM(const ELM& orig) {
	}

	ELM::~ELM() {
	}

	//Declare variables.
	int ELM::numDevices;
	Device * ELM::deviceList;
	std::string ELM::preMaterial;
	std::string ELM::postMaterial;

	//Level IV
	void ELM::getPreMaterial(std::string filename) {

		std::ifstream readIn(filename.c_str());
		std::string buf_string;

		preMaterial = "";
		while (std::getline(readIn, buf_string, '\n')) {
			preMaterial.append(buf_string.append("\n"));
			if (matchHeaderXML(buf_string, XMLParse::LAYERS_END))
				break;
		}
		readIn.close();
	}
	void ELM::getPostMaterial(std::string filename) {

		std::ifstream readIn(filename.c_str());

		std::string buf_string;
		bool postMaterial_FLAG = false;

		postMaterial = "";
		while (std::getline(readIn,buf_string,'\n')) {
			
			if (matchHeaderXML(buf_string, XMLParse::DRAWING_END))
				postMaterial_FLAG = true;

			if (postMaterial_FLAG == true) {
				postMaterial.append(buf_string.append("\n"));
			}

		}
		postMaterial = postMaterial.substr(0, postMaterial.length() - 1);

		readIn.close();
	}
	bool ELM::isValidName(std::string name) {
		//to be valid:
			//name cannot have spaces.
			//name cannot have lowercase letters.

		if (name.find(" ") != std::string::npos)
			return false;
		for (char c : name) {
			if (islower(c))
				return false;
		}
		return true;
	}

	//Level III
	void ELM::countDevices(std::string filename) {

		std::ifstream readIn(filename.c_str());

		numDevices = 0;
		std::string buf_string;

		while (std::getline(readIn, buf_string, '\n')) {

			if (matchHeaderXML(buf_string, XMLParse::DEVICESET_START)) {
				//std::cout<<buf_string<<'\n';
				numDevices++;
			}

		}
		
		readIn.close();
	}
	bool ELM::matchHeaderXML(std::string buf_string, XMLParse::XML_TAGS match_header_xml) {

		switch (match_header_xml)
		{
		case XMLParse::DEVICESET_START:
			return (buf_string.find("<deviceset name=") != std::string::npos);
		case XMLParse::DEVICESET_END:
			return (buf_string.find("</deviceset>") != std::string::npos);
		case XMLParse::SYMBOL_START:
			return (buf_string.find("<symbol name=") != std::string::npos);
		case XMLParse::SYMBOL_END:
			return (buf_string.find("</symbol>") != std::string::npos);
		case XMLParse::PACKAGE_START:
			return (buf_string.find("<package name=") != std::string::npos);
		case XMLParse::PACKAGE_END:
			return (buf_string.find("</package>") != std::string::npos);
		case XMLParse::LAYERS_END:
			return (buf_string.find("</layers>") != std::string::npos);
		case XMLParse::DEVICESETS_END:
			return (buf_string.find("</devicesets>") != std::string::npos);
		case XMLParse::DRAWING_END:
			return (buf_string.find("</drawing>") != std::string::npos);
		default:
			return false;
		}

	}
	int ELM::findDeviceName(std::string nameToFind) {
		//returns an integer corresponding to the index n s/t dlist[n].name == name.
		//if not found, returns -1.

		for (int n = 0; n < numDevices; n++) {
			if (deviceList[n].name.compare(nameToFind) == 0)
				return n;
		}
		return -1;
	}

	//Level II
	std::string ELM::getXML_givenName(std::string filename, std::string name, XMLParse::XML_TAGS START_ENUM, XMLParse::XML_TAGS END_ENUM) {
		//Gets XML for any name, for any Class. (Device, package, or symbol).

		std::ifstream readIn(filename.c_str());

		readIn.clear();
		readIn.seekg(0, readIn.beg);

		std::string XML_out = "";
		std::string buf_string;

		bool nameFound_FLAG = false;
		while (std::getline(readIn,buf_string, '\n')) {

			if ((matchHeaderXML(buf_string, START_ENUM)) && (name.compare(XMLParse::nameFromXML(buf_string)) == 0)) {

				//Once you find this start tag, and it's the name you want.
				nameFound_FLAG = true;

				//Tack on the XML.
				buf_string.append("\n");
				XML_out.append(buf_string);

				//Get the rest of the XML code.
				while (!matchHeaderXML(buf_string, END_ENUM)) { //While you don't see end-tag
					std::getline(readIn, buf_string, '\n');
					buf_string.append("\n");
					XML_out.append(buf_string); //Tack it on 
				}
				break;
			}
		}

		readIn.close();
		return XML_out;
	}
	void ELM::getXML_AllDevices(std::string filename) {

		//Returns a Device * with all your devices, and their XML / name filled out.
		deviceList = new Device[numDevices];
		int device_ind = 0;

		std::ifstream readIn(filename.c_str());

		std::string buf_string;
		std::string XML_out;

		while (std::getline(readIn, buf_string, '\n')) {

			if (matchHeaderXML(buf_string, XMLParse::DEVICESET_START)) {
				//You find a start tag.

				//Tack on the XML.
				buf_string.append("\n");
				XML_out.append(buf_string);

				//Get the rest of the XML code.
				while (!matchHeaderXML(buf_string, XMLParse::DEVICESET_END)) { //While you don't see end-tag
					std::getline(readIn, buf_string, '\n'); //Read in new line
					buf_string.append("\n");
					XML_out.append(buf_string); //Tack it on 
				}

				deviceList[device_ind].XMLtext = XML_out;
				deviceList[device_ind].name = XMLParse::nameFromXML(XML_out);

				device_ind++;
				XML_out = "";

				if (device_ind == numDevices)
					break;
			}
		}
		readIn.close();
	}
	void ELM::makeDeviceList(std::string filename) {

		deviceList = new Device[numDevices];
		ELM::getXML_AllDevices(filename);

		for (int device_ind = 0; device_ind < numDevices; device_ind++) {

			deviceList[device_ind].s.name = deviceList[device_ind].name;
			deviceList[device_ind].s.XMLtext =
				ELM::getXML_givenName(filename, deviceList[device_ind].s.name, XMLParse::SYMBOL_START, XMLParse::SYMBOL_END);

			deviceList[device_ind].p.name = deviceList[device_ind].name;
			deviceList[device_ind].p.XMLtext =
				ELM::getXML_givenName(filename, deviceList[device_ind].p.name, XMLParse::PACKAGE_START, XMLParse::PACKAGE_END);

		}
	}
	void ELM::addToDeviceList(Device d) {

		//Make room
		Device * deviceList_OLD = ELM::deviceList;
		ELM::deviceList = new Device[ELM::numDevices + 1];

		//Copy
		for (int n = 0; n < ELM::numDevices; n++)
			ELM::deviceList[n] = deviceList_OLD[n];

		//Add new
		ELM::deviceList[ELM::numDevices] = d;
		ELM::numDevices++;

	}

	//Level I
	void ELM::ReadFileIn(std::string filename) {
		ELM::countDevices(filename); //count the number of devices
		ELM::makeDeviceList(filename); //make the device list
		
		ELM::getPreMaterial(filename); //everything before devices, packages, symbols we care about
		ELM::getPostMaterial(filename); //everything after devices, packages, symbols we care about
	}
	void ELM::WriteFileOut(std::string filename) {

		remove(filename.c_str());

		std::ofstream writeOut(filename.c_str());
		writeOut.flush();

		//If filename exists: Delete it.
		//This gets it out of our way when we're about to write.
		//std::remove(filename.c_str());

		//Concatenate XMLs of each Package.
		//Wrap this concatenated XML in tag <packages></packages>.
		std::string packageXML;
		for (int n = 0; n < numDevices; n++)
			packageXML.append(deviceList[n].p.XMLtext);
		packageXML = XMLParse::tagWrapXML(packageXML, "<packages>", "</packages>");

		//Concatenate XMLs of each Symbol.
		//Wrap this concatenated XML in tag <symbols></symbols>.
		std::string symbolXML;
		for (int n = 0; n < numDevices; n++)
			symbolXML.append(deviceList[n].s.XMLtext);
		symbolXML = XMLParse::tagWrapXML(symbolXML, "<symbols>", "</symbols>");

		//Concatenate XMLs of each Device.
		//Wrap this concatenated XML in tag <devicesets></devicesets>.
		std::string deviceXML;
		for (int n = 0; n < numDevices; n++)
			deviceXML.append(deviceList[n].XMLtext);
		deviceXML = XMLParse::tagWrapXML(deviceXML, "<devicesets>", "</devicesets>");

		//Concatenate the three aforementioned XMLs.
		//Wrap this concatenated XML in tag <library></library>.
		std::string libraryXML;
		libraryXML = packageXML.append(symbolXML.append(deviceXML));
		libraryXML = XMLParse::tagWrapXML(libraryXML, "<library>", "</library>");

		//Concatenate pre-material(settings, layers..) and post-material(tags..).
		std::string XML_out = preMaterial.append(libraryXML.append(postMaterial));

		writeOut << XML_out;
		
		writeOut.close();
	}
	int ELM::RemoveDevices(std::vector<std::string> namesToRemove) {

		int nameInd;
		int numRemoved = 0;
		
		for (std::string name_remove : namesToRemove) {

			//For each name you want to remove.
			//Try to find that name in deviceList.
			nameInd = ELM::findDeviceName(name_remove);

			if (nameInd == -1) //If not found:
				continue; //continue
			
			//If found:
			//Declare a new deviceList pointer with one less size than before
			Device * temp = deviceList;
			deviceList = new Device[numDevices - 1];

			//I iterate through temp.
				//I shuffle everything on top of the term at nameInd.
			for (int n = nameInd; n + 1 < numDevices; n++)
				temp[n] = temp[n + 1];

			//Now it's organized for me to do a term-by-term into deviceList.
			for (int n = 0; n < numDevices - 1; n++)
				deviceList[n] = temp[n];

			numDevices--;
			numRemoved++;

			
		}

		return numRemoved;
	}
	int ELM::AddNewDevices(std::vector<std::string> namesToAdd) {

		//Adding devices...

		//Ensure you don't have duplicate names in namesToAdd vs. deviceList:
		int numToAdd = 0;
		std::vector<std::string> namesToAdd_TRUE;
		for (std::string name : namesToAdd) {
			//For each item in namesToAdd
			if ((ELM::findDeviceName(name) == -1) && ELM::isValidName(name)) { //Only if we don't have this name AND it is valid.
				namesToAdd_TRUE.push_back(name); //Mark to add.
				numToAdd++; //Increment numToAdd
			}
		}

		//Generate new deviceList.
			//Load current deviceList into deviceList_OLD.
		Device * deviceList_OLD = deviceList;

		//Make a new pointer to store new deviceList.
		deviceList = new Device[numDevices + numToAdd];

		//Put deviceList_OLD at the beginning of newDeviceList.
		for (int n = 0; n < numDevices; n++)
			deviceList[n] = deviceList_OLD[n];

		//Initialize each new device with dummy XML text and given names.
		Device * deviceList_ADD = Device::makeDummyDevices(namesToAdd_TRUE);
		for (int n = numDevices; n < numDevices + numToAdd; n++)
			deviceList[n] = deviceList_ADD[n - numDevices];

		numDevices += numToAdd; //Increase numDevices

		return numToAdd;
	}
	
	void ELM::AddDevice_2xN(
		std::string d_name,
		std::vector<std::string> padNames,
		double d_space_x, double d_space_y, double d_dim_x, double d_dim_y, int N
	) {
		if (ELM::findDeviceName(d_name) == -1) {
			Device d(d_name, padNames, d_space_x, d_space_y, d_dim_x, d_dim_y, N);
			//Device d(d_name);
			
			//Make room
			Device * deviceList_OLD = ELM::deviceList;
			ELM::deviceList = new Device[ELM::numDevices + 1];

			//Copy
			for (int n = 0; n < ELM::numDevices; n++)
				ELM::deviceList[n] = deviceList_OLD[n];

			//Add new
			ELM::deviceList[ELM::numDevices] = d;
			ELM::numDevices++;

		}
	}

	void ELM::AddDevice_RA(
		std::string d_name,
		std::vector<std::string> d_padNames,
		double d_REF, int d_N, double d_padW, double d_padL, double d_padSpace,
		double d_centeredSquarePad_DIM,
		double d_cornerSquarePads_REF, double d_cornerSquarePads_DIM
	) {
		if (ELM::findDeviceName(d_name) == -1) {
			Device d(
				d_name,
				d_padNames,
				d_REF, d_N, d_padW, d_padL, d_padSpace,
				d_centeredSquarePad_DIM,
				d_cornerSquarePads_REF, d_cornerSquarePads_DIM
			);
			//Device d(d_name);
			
			//Make room
			Device * deviceList_OLD = ELM::deviceList;
			ELM::deviceList = new Device[ELM::numDevices + 1];

			//Copy
			for (int n = 0; n < ELM::numDevices; n++)
				ELM::deviceList[n] = deviceList_OLD[n];

			//Add new
			ELM::deviceList[ELM::numDevices] = d;
			ELM::numDevices++;
		}
	}

	void ELM::AddDevice_RxR(
		std::string d_name,
		std::vector<std::string> d_padNames,
		int d_N_rows,
		int* d_N_pads, double* d_padX, double* d_padY, double* d_padSpace, //length N_rows
		double* d_horizontalOffset, double* d_verticalOffset //length N_rows - 1
	) {
		if (findDeviceName(d_name) == -1) {
			Device d(
				d_name,
				d_padNames,
				d_N_rows,
				d_N_pads, d_padX, d_padY, d_padSpace, //length N_rows
				d_horizontalOffset, d_verticalOffset //length N_rows - 1
			);
			//Device d(d_name);
			
			//Make room
			Device * deviceList_OLD = ELM::deviceList;
			ELM::deviceList = new Device[ELM::numDevices + 1];

			//Copy
			for (int n = 0; n < ELM::numDevices; n++)
				ELM::deviceList[n] = deviceList_OLD[n];

			//Add new
			ELM::deviceList[ELM::numDevices] = d;
			ELM::numDevices++;
		}
	}
	
}