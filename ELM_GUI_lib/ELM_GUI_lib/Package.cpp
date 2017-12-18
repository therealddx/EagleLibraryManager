#include "Stdafx.h"
#include "Package.h"

namespace ELM_GUI_lib {

	//Blank
	Package::Package() {
		name = "";
		XMLtext = "";
	}

	//Dummy: Minimal acceptable by Eagle
	Package::Package(std::string d_name) {
		name = d_name;
		XMLtext = XMLParse::generateTag(XMLParse::XML_TAGS::PACKAGE_START, name);
		XMLtext.append(XMLParse::generateTag(XMLParse::GENERIC_NAME_PACKAGE));
		XMLtext.append(XMLParse::generateTag(XMLParse::XML_TAGS::PACKAGE_END));
	}

	//General 2xN.
	Package::Package(
		std::string d_packageName,
		std::vector<std::string> d_padNames,
		double d_space_x, double d_space_y, double d_dim_x, double d_dim_y, int N
	) {
		name = d_packageName;
		numPads = 2 * N;
		pads = new SMD[numPads];

		std::vector<std::string> padNames_cut(N);

		padNames_cut = Package::extractN(d_padNames, N, 0);
		loadPadRow(padNames_cut, d_space_x, d_dim_x, d_dim_y, N, 0, 0, 0, 0);
		padNames_cut = Package::extractN(d_padNames, N, N);
		loadPadRow(padNames_cut, -d_space_x, d_dim_x, d_dim_y, N, N, (N-1) * d_space_x, d_space_y, 0);
	}

	int Package::calc_RA_numPads(int d_N, double d_cornerSquarePads_DIM, double d_centeredSquarePad_DIM) {
		
		return 4 * d_N + 
			4 * (d_cornerSquarePads_DIM > 0) + 
			1 * (d_centeredSquarePad_DIM > 0);
	}
	//RA.
	Package::Package(
		std::string d_name,
		std::vector<std::string> d_padNames,
		double d_REF, int d_N, double d_padW, double d_padL, double d_padSpace,
		double d_centeredSquarePad_DIM,
		double d_cornerSquarePads_REF, double d_cornerSquarePads_DIM
		) {
		
		name = d_name;
		numPads = calc_RA_numPads(d_N, d_cornerSquarePads_DIM, d_centeredSquarePad_DIM);
		pads = new SMD[numPads];

		bool placeCenteredPad = d_centeredSquarePad_DIM > 0;
		bool placeCornerPads = d_cornerSquarePads_DIM > 0;
		
		double z = (d_N - 1) * d_padSpace;//Top height of vertical row center line
		double cx = d_REF / 2; double cy = z / 2;//Center of package shape.

		//if <>, place corner.
		//Make row.
		//--------->x4.
		//if <>, place center.

		std::vector<std::string> d_padNames_cut(d_N);
		
		//Place main pads and corner pads.
		if (placeCornerPads) {

			double cornerPad_L = d_cornerSquarePads_DIM;
			double cornerPad_W = d_cornerSquarePads_DIM;
			if (d_cornerSquarePads_DIM > 10000) {
				cornerPad_L = d_padL;
				cornerPad_W = d_padW;
			}

			//UL to LL (down)
			loadPad(d_padNames[0], cornerPad_L, cornerPad_W, cx - d_cornerSquarePads_REF / 2, cy + d_cornerSquarePads_REF / 2, 0);
			d_padNames_cut = extractN(d_padNames, d_N, 0 + 1);
			loadPadRow(d_padNames_cut, -d_padSpace, d_padL, d_padW, d_N, 0 + 1, 0, z, 1);

			//LL to LR (right)
			loadPad(d_padNames[d_N + 1], cornerPad_L, cornerPad_W, cx - d_cornerSquarePads_REF / 2, cy - d_cornerSquarePads_REF / 2, d_N + 1);
			d_padNames_cut = extractN(d_padNames, d_N, d_N + 1 + 1);
			loadPadRow(d_padNames_cut, d_padSpace, d_padW, d_padL, d_N, d_N + 1 + 1, cx - z/2, cy - d_REF/2, 0);

			//LR to UR (up)
			loadPad(d_padNames[2*(d_N + 1)], cornerPad_L, cornerPad_W, cx + d_cornerSquarePads_REF / 2, cy - d_cornerSquarePads_REF / 2, 2*(d_N + 1));
			d_padNames_cut = extractN(d_padNames, d_N, 2*(d_N + 1) + 1);
			loadPadRow(d_padNames_cut, d_padSpace, d_padL, d_padW, d_N, 2*(d_N + 1) + 1, d_REF, 0, 1);

			//UR to UL (left)
			loadPad(d_padNames[3*(d_N + 1)], cornerPad_L, cornerPad_W, cx + d_cornerSquarePads_REF / 2, cy + d_cornerSquarePads_REF / 2, 3 * (d_N + 1));
			d_padNames_cut = extractN(d_padNames, d_N, 3*(d_N + 1) + 1);
			loadPadRow(d_padNames_cut, -d_padSpace, d_padW, d_padL, d_N, 3*(d_N + 1) + 1, cx + z/2, cy + d_REF/2, 0);

		}
		else {
			
			d_padNames_cut = extractN(d_padNames, d_N, 0);
			loadPadRow(d_padNames_cut, -d_padSpace, d_padL, d_padW, d_N, 0, 0, z, 1);

			d_padNames_cut = extractN(d_padNames, d_N, d_N);
			loadPadRow(d_padNames_cut, d_padSpace, d_padW, d_padL, d_N, d_N, cx - z / 2, cy - d_REF / 2, 0);

			d_padNames_cut = extractN(d_padNames, d_N, 2 * d_N);
			loadPadRow(d_padNames_cut, d_padSpace, d_padL, d_padW, d_N, 2 * d_N, d_REF, 0, 1);
			
			d_padNames_cut = extractN(d_padNames, d_N, 3 * d_N);
			loadPadRow(d_padNames_cut, -d_padSpace, d_padW, d_padL, d_N, 3 * d_N, cx + z / 2, cy + d_REF / 2, 0);

		}
		
		//Place centered pad.
		if (placeCenteredPad) {
			loadPad(d_padNames[numPads - 1], d_centeredSquarePad_DIM, d_centeredSquarePad_DIM, cx, cy, numPads - 1);
		}
	}

	int Package::calc_RXR_numPads(int* d_N_pads, int N_rows) {
		int totalNumPads = 0;
		for (int n = 0; n < N_rows; n++) {
			totalNumPads += d_N_pads[n];
		}
		return totalNumPads;
	}
	//RxR.
	Package::Package(
		std::string d_name,
		std::vector<std::string> d_padNames,
		int d_N_rows,
		int* d_N_pads, double* d_padX, double* d_padY, double* d_padSpace, //length N_rows
		double* d_horizontalOffset, double* d_verticalOffset //length N_rows - 1
	) {
		name = d_name;
		numPads = calc_RXR_numPads(d_N_pads, d_N_rows);
		pads = new SMD[numPads];

		std::vector<std::string> padNames_cut;
		double cur_loc_x = 0;
		double cur_loc_y = 0;
		int offsetThusFar = 0;
		for (int n = 0; n < d_N_rows; n++) {
			padNames_cut = extractN(d_padNames, d_N_pads[n], offsetThusFar);
			loadPadRow(padNames_cut, d_padSpace[n], d_padX[n], d_padY[n], d_N_pads[n], offsetThusFar, cur_loc_x, cur_loc_y, 1);
			offsetThusFar += d_N_pads[n];

			if (n + 1 < d_N_rows) {
				cur_loc_x += d_horizontalOffset[n];
				cur_loc_y += d_verticalOffset[n];
			}
		}
	}

	Package::Package(const Package& orig) {
	}

	Package::~Package() {
	}

	std::vector<std::string> Package::extractN(std::vector<std::string> vecIn, int numOut, int offset) {
		std::vector<std::string> vecOut(numOut);
		for (int n = offset; n < offset + numOut; n++)
			vecOut[n - offset] = vecIn[n];
		return vecOut;
	}

	//Make a row of pads.
	void Package::loadPadRow(
		std::vector<std::string> d_padNames,
		double d_space, double d_dim_x, double d_dim_y,
		int N, int offset,
		double d_origin_x, double d_origin_y, int direction
	) {

		//direction == 0: +right, -left.
		//direction == 1: +up, -down.

		//Generate new pads.
		double cur_loc_x = d_origin_x;
		double cur_loc_y = d_origin_y;
		if (direction == 0) {
			for (int n = offset; n < offset + N; n++) {
				SMD smd(d_padNames[n - offset], cur_loc_x, cur_loc_y, d_dim_x, d_dim_y, 1);
				pads[n] = smd;
				cur_loc_x += d_space;
			}
		}
		else if (direction == 1) {
			for (int n = offset; n < offset + N; n++) {
				SMD smd(d_padNames[n - offset], cur_loc_x, cur_loc_y, d_dim_x, d_dim_y, 1);
				pads[n] = smd;
				cur_loc_y += d_space;
			}
		}

		//Regenerate XML.
		XMLtext = "";
		XMLtext = XMLParse::generateTag(XMLParse::PACKAGE_START, name);
		for (int n = 0; n < numPads; n++)
			XMLtext.append(pads[n].XMLtext);
		XMLtext.append(XMLParse::generateTag(XMLParse::GENERIC_NAME_PACKAGE));
		XMLtext.append(XMLParse::generateTag(XMLParse::PACKAGE_END));
		
	}

	void Package::loadPad(
		std::string d_padName,
		double d_dim_x, double d_dim_y, double origin_x, double origin_y,
		int offset
	) {
		SMD smd(d_padName, origin_x, origin_y, d_dim_x, d_dim_y, 1);
		pads[offset] = smd;

		//Regenerate XML.
		XMLtext = "";
		XMLtext = XMLParse::generateTag(XMLParse::PACKAGE_START, name);
		for (int n = 0; n < numPads; n++)
			XMLtext.append(pads[n].XMLtext);
		XMLtext.append(XMLParse::generateTag(XMLParse::GENERIC_NAME_PACKAGE));
		XMLtext.append(XMLParse::generateTag(XMLParse::PACKAGE_END));
	}
	

}