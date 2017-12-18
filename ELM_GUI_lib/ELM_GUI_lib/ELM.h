#include "Stdafx.h"

#ifndef ELM_H
#define ELM_H

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <stdio.h>

#include "XMLParse.h"
#include "Symbol.h"
#include "Package.h"
#include "Device.h"

namespace ELM_GUI_lib {

	public class ELM {
	public:

		ELM();
		ELM(const ELM& orig);
		virtual ~ELM();

		static int numDevices;
		static Device * deviceList;

		static bool isValidName(std::string name);
		
		//Primaries.
		static void ReadFileIn(std::string filename);
		static void WriteFileOut(std::string filename);
		static int RemoveDevices(std::vector<std::string> namesToRemove);
		static int AddNewDevices(std::vector<std::string> namesToAdd);
		
		static void AddDevice_2xN(
			std::string d_name,
			std::vector<std::string> padNames,
			double d_space_x, double d_space_y, double d_dim_x, double d_dim_y, int N
		);
		static void AddDevice_RA(
			std::string d_name,
			std::vector<std::string> d_padNames,
			double d_REF, int d_N, double d_padW, double d_padL, double d_padSpace,
			double d_centeredSquarePad_DIM,
			double d_cornerSquarePads_REF, double d_cornerSquarePads_DIM
		);
		static void AddDevice_RxR(
			std::string d_name,
			std::vector<std::string> d_padNames,
			int d_N_rows,
			int* d_N_pads, double* d_padX, double* d_padY, double* d_padSpace, //length N_rows
			double* d_horizontalOffset, double* d_verticalOffset //length N_rows - 1
		);

	private:

		//ReadFileIn Helpers
		static bool matchHeaderXML(std::string buf_string, XMLParse::XML_TAGS match_header_xml);
		static std::string getXML_givenName(std::string filename, std::string name, XMLParse::XML_TAGS START_ENUM, XMLParse::XML_TAGS END_ENUM);
		static void getXML_AllDevices(std::string filename);
		static void makeDeviceList(std::string filename);
		static void countDevices(std::string filename);

		//Remove Helpers
		static int findDeviceName(std::string nameToFind);

		//Add Helpers
		static void addToDeviceList(Device d);

		//Other Helpers
		static std::string preMaterial;
		static std::string postMaterial;
		static void getPreMaterial(std::string filename);
		static void getPostMaterial(std::string filename);
	};

}

#endif /* ELM_H */

//Options from here:
    //Adding devices - We want to be able to add devices quickly.
    //Goal: I never have to draw another stupid fucking pad again.
        //To me, the bare bones of a Package is a group of pads.
        //The spacing between the pads is what makes drawing time-consuming.
            //-gotit

        //A tPlace drawing that covers the footprint of the pads in
        //some respect would be nice.

    //How about the symbol, is that something that offends me?
        //Second priority of annoyingness is having to place all those
        //pins around my symbol and edit their properties manually.
            //Ok - pin / pad discussion. As we know symbol and package are
            //constructed separately, however, they will be constructed
            //in a higher-level function (of - say, Device), so they can
            //be made to have one-to-one matching of pin / pad names.
            
            //Goal is that Symbol is drawn to match the array of pads that
            //Package presents. The advantage for me here is that since the
            //view is all schematic, I can just offer equal grid spacing.

        //I at least want a box that is automatically generated - but
        //more importantly, I want pins that are named and spaced
        //appropriately.

    //The last priority is connecting that package to that symbol in Eagle.
    //Making the connections myself is very easy - but it would be nice if
    //this was done automatically, as well.