#include "Stdafx.h"

#ifndef DEVICE_H
#define DEVICE_H

#include <string>
#include <vector>
#include "XMLParse.h"
#include "Package.h"
#include "Symbol.h"

namespace ELM_GUI_lib {

	public class Device {
	public:
		Device();
		Device(std::string d_name);
		Device(std::string d_name, std::string d_XMLtext);

		//Generate 2xN.
		Device(
			std::string d_name,
			std::vector<std::string> padNames,
			double d_space_x, double d_space_y, double d_dim_x, double d_dim_y, int N
		);

		//Generate RA.
		Device(
			std::string d_name,
			std::vector<std::string> d_padNames,
			double d_REF, int d_N, double d_padW, double d_padL, double d_padSpace,
			double d_centeredSquarePad_DIM,
			double d_cornerSquarePads_REF, double d_cornerSquarePads_DIM
		);

		//Generate RxR.
		Device(
			std::string d_name,
			std::vector<std::string> d_padNames,
			int d_N_rows,
			int* d_N_pads, double* d_padX, double* d_padY, double* d_padSpace, //length N_rows
			double* d_horizontalOffset, double* d_verticalOffset //length N_rows - 1)
		);

		Device(const Device& orig);
		virtual ~Device();

		std::string name;
		std::string XMLtext;
		Package p;
		Symbol s;

		void compileXML(std::vector<std::string> padNames);
		static Device * makeDummyDevices(std::vector<std::string> nameList);
		//So for me to make a device that holds p and s.
			//I need the template XML again, for what a <deviceset..> looks like
			//when it connects a package and symbol of a given name.

			//Assuming I have that: in the constructor for the device object,
			//construct the Package and Symbol. Call for arguments as desired - 
			//overloads / defaults can be presented.

			//Then generate the deviceset XML according to the template.

		/*
		<deviceset name="VCO_805-900MHZ">
		<gates>
		<gate name="G$1" symbol="VCO_805-900MHZ" x="60.96" y="5.08"/>
		</gates>
		<devices>
		<device name="" package="VCO_805-900MHZ">
		<connects>
		<connect gate="G$1" pin="GND" pad="GND0 GND1 GND2 GND3 GND4 GND5 GND6 GND7 GND8 GND9 GND10 GND11 GND12"/>
		<connect gate="G$1" pin="RF" pad="RF"/>
		<connect gate="G$1" pin="VCC" pad="VCC"/>
		<connect gate="G$1" pin="VT" pad="VT"/>
		</connects>
		<technologies>
		<technology name=""/>
		</technologies>
		</device>
		</devices>
		</deviceset>
		 */
	};

}

#endif /* DEVICE_H */

