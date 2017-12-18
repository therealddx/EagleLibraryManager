#include "Stdafx.h"
#include "Device.h"

namespace ELM_GUI_lib {

	Device::Device() {
		p = Package();
		s = Symbol();

		name = "";
		XMLtext = "";
	}

	Device::Device(std::string d_name) {

		/*
		<deviceset name="DUMMY">
		<gates>
		</gates>
		<devices>
		<device name="">
		<technologies>
		<technology name=""/>
		</technologies>
		</device>
		</devices>
		</deviceset>
		*/

		name = d_name;
		p = Package(name);
		s = Symbol(name);

		XMLtext = XMLParse::generateTag(XMLParse::XML_TAGS::DEVICESET_START, name);

		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::GATES_START));
		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::GATES_END));

		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::DEVICES_START));

		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::DEVICE_START));
		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::TECHNOLOGIES_START));
		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::TECHNOLOGY));
		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::TECHNOLOGIES_END));
		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::DEVICE_END));

		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::DEVICES_END));

		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::DEVICESET_END));
	}

	Device::Device(std::string d_name, std::string d_XMLtext) {
		p = Package(d_name);
		s = Symbol(d_name);
		name = d_name;
		XMLtext = d_XMLtext;
	}

	void Device::compileXML(std::vector<std::string> padNames) {

		XMLtext = XMLParse::generateTag(XMLParse::DEVICESET_START, name);

		XMLtext.append(XMLParse::generateTag(XMLParse::GATES_START));
		XMLtext.append(XMLParse::generateTag(XMLParse::GATE, name));
		XMLtext.append(XMLParse::generateTag(XMLParse::GATES_END));

		XMLtext.append(XMLParse::generateTag(XMLParse::DEVICES_START));
		XMLtext.append(XMLParse::generateTag(XMLParse::DEVICE_START, name));

		XMLtext.append(XMLParse::generateTag(XMLParse::CONNECTS_START));
		for (std::string cur_name : padNames)
			XMLtext.append(XMLParse::generateTag(XMLParse::CONNECT, cur_name));
		XMLtext.append(XMLParse::generateTag(XMLParse::CONNECTS_END));

		XMLtext.append(XMLParse::generateTag(XMLParse::TECHNOLOGIES_START));
		XMLtext.append(XMLParse::generateTag(XMLParse::TECHNOLOGY));
		XMLtext.append(XMLParse::generateTag(XMLParse::TECHNOLOGIES_END));

		XMLtext.append(XMLParse::generateTag(XMLParse::DEVICE_END));
		XMLtext.append(XMLParse::generateTag(XMLParse::DEVICES_END));
		XMLtext.append(XMLParse::generateTag(XMLParse::DEVICESET_END));

	}

	//Generates 2xN Device.
	Device::Device(
		std::string d_name,
		std::vector<std::string> padNames,
		double d_space_x, double d_space_y, double d_dim_x, double d_dim_y, int N
	) {

		Package p_new(d_name, padNames, d_space_x, d_space_y, d_dim_x, d_dim_y, N);
		//Package p_new(d_name);
		p = p_new;
		
		Symbol s_new(d_name, padNames, N*2);
		//Symbol s_new(d_name);
		s = s_new;

		name = d_name;
		compileXML(padNames);

		//Grouping pins will have to be presented as an option.

		//One example deviceset connection looks like this:

	//    <deviceset name="VCO_805-900MHZ">
	//    <gates>
	//    <gate name="G$1" symbol="VCO_805-900MHZ" x="60.96" y="5.08"/>
	//    </gates>
	//    <devices>
	//    <device name="" package="VCO_805-900MHZ">
	//    <connects>
	//    <connect gate="G$1" pin="GND" pad="GND0 GND1 GND2 GND3 GND4 GND5 GND6 GND7 GND8 GND9 GND10 GND11 GND12"/>
	//    <connect gate="G$1" pin="RF" pad="RF"/>
	//    <connect gate="G$1" pin="VCC" pad="VCC"/>
	//    <connect gate="G$1" pin="VT" pad="VT"/>
	//    </connects>
	//    <technologies>
	//    <technology name=""/>
	//    </technologies>
	//    </device>
	//    </devices>
	//    </deviceset>

	}

	//Generate RA.
	Device::Device(
		std::string d_name,
		std::vector<std::string> d_padNames,
		double d_REF, int d_N, double d_padW, double d_padL, double d_padSpace,
		double d_centeredSquarePad_DIM,
		double d_cornerSquarePads_REF, double d_cornerSquarePads_DIM
	) {
		Package p_new(
			d_name,
			d_padNames,
			d_REF, d_N, d_padW, d_padL, d_padSpace,
			d_centeredSquarePad_DIM,
			d_cornerSquarePads_REF, d_cornerSquarePads_DIM
		);
		//Package p_new(d_name);
		p = p_new;

		Symbol s_new(d_name, d_padNames, p.numPads);
		//Symbol s_new(d_name);
		s = s_new;

		name = d_name;
		compileXML(d_padNames);
	}

	//Generate RxR.
	Device::Device(
		std::string d_name,
		std::vector<std::string> d_padNames,
		int d_N_rows,
		int* d_N_pads, double* d_padX, double* d_padY, double* d_padSpace, //length N_rows
		double* d_horizontalOffset, double* d_verticalOffset //length N_rows - 1
	) {
		Package p_new(
			d_name,
			d_padNames,
			d_N_rows,
			d_N_pads, d_padX, d_padY, d_padSpace, //length N_rows
			d_horizontalOffset, d_verticalOffset //length N_rows - 1
		);
		//Package p_new(d_name);
		p = p_new;

		Symbol s_new(d_name, d_padNames, p.numPads);
		//Symbol s_new(d_name);
		s = s_new;

		name = d_name;
		compileXML(d_padNames);
	}

	Device::Device(const Device& orig) {
	}

	Device::~Device() {
	}

	Device * Device::makeDummyDevices(std::vector<std::string> nameList) {

		int numDummyDevices = nameList.size();
		Device * dummyDeviceList = new Device[numDummyDevices];

		for (int n = 0; n < numDummyDevices; n++) {
			dummyDeviceList[n] = Device(nameList[n]);
		}

		return dummyDeviceList;
	}
}