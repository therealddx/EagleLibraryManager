#include "Stdafx.h"

#ifndef PACKAGE_H
#define PACKAGE_H

#include <string>
#include <vector>
#include "XMLParse.h"
#include "SMD.h"

namespace ELM_GUI_lib {

	public class Package {
	public:

		Package();
		Package(std::string d_name);
		Package(const Package& orig);
		
		//Generates 2xN.
		Package(
			std::string d_packageName,
			std::vector<std::string> d_padNames,
			double d_space_x, double d_space_y, double d_dim_x, double d_dim_y, int N
		);

		//Generates RA.
		Package(
			std::string d_name,
			std::vector<std::string> d_padNames,
			double d_REF, int d_N, double d_padW, double d_padL, double d_padSpace,
			double d_centeredSquarePad_DIM,
			double d_cornerSquarePads_REF, double d_cornerSquarePads_DIM
		);

		//Generates RxR.
		Package(
			std::string d_name,
			std::vector<std::string> d_padNames,
			int d_N_rows,
			int* d_N_pads, double* d_padX, double* d_padY, double* d_padSpace, //length N_rows
			double* d_horizontalOffset, double* d_verticalOffset //length N_rows - 1
		);

		//Helpers.
		void loadPadRow(
			std::vector<std::string> d_padNames,
			double d_space, double d_dim_x, double d_dim_y,
			int N, int offset,
			double d_origin_x, double d_origin_y, int direction
		);

		void loadPad(
			std::string d_padName,
			double d_dim_x, double d_dim_y, double origin_x, double origin_y,
			int offset
		);

		static std::vector<std::string> extractN(std::vector<std::string> vecIn, int numOut, int offset);
		static int calc_RA_numPads(int d_N, double d_cornerSquarePads_DIM, double d_centeredSquarePad_DIM);
		static int calc_RXR_numPads(int* d_N_pads, int N_rows);

		virtual ~Package();

		std::string XMLtext;
		std::string name;

		int numPads;
		SMD* pads;

		//Before writing the function that generates the Package's XML from the pads,
		//we have to refactor so it's the Package that generates the XML in teh first place
		//not ELM.

		//So what it looks like, is:
		//My Package needs an array of SMD pads.
			//One package gets one text field for ">NAME".
			//<text x="-0.635" y="-2.54" size="1.27" layer="25">&gt;NAME</text>

		//What characterizes a Package.
			//<wire "" /> : Simple line.
			//<dimension "" /> : Dimension object.
			//<smd "" /> : SMD object.

	private:

	};
}

#endif /* PACKAGE_H */

