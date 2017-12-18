// This is the main DLL file.

#include "stdafx.h"
#include <string>

#include "ELM_GUI_lib.h"

namespace ELM_GUI_lib {

	//C++: string to char[] (std::string.c_str())
	//C++: string[] to char[]
	//C++: char[] to string (std::string mystring = thatcharbuffer)
	//C++: char[] to string[]

	char* INTEROP_DRIVER::stringArrayToCharArray(std::vector<std::string> stringsIn) {
		//For each string you have.
		//Convert that string to a char array.
		//Concatenate that char array onto master + ,

		char* master;
		int n = 0;
		int k = 0;

		int totalLength = 0;
		for (std::string s : stringsIn)
			totalLength += s.length() + 1;
		totalLength += 1;//for \0 at end

		master = new char[totalLength];

		for (std::string s : stringsIn) {

			for (n = 0; n < s.length(); n++) {
				master[n + k] = s[n];
			}
			master[n + k] = ',';
			k += n + 1;
		}
		master[totalLength - 1] = '\0';

		return master;
	}
	void INTEROP_DRIVER::clear_charbuf(char charsIn[], int len) {
		for (int n = 0; n < len; n++)
			charsIn[n] = '\0';
	}
	std::vector<std::string> INTEROP_DRIVER::charArrayToStringArray(char* charsIn) {

		//You have charsIn.
		////Scan through.
		//Tack on letters til you see a comma.
		//when you do take the substring.

		//Compute length.
		int totalLength = 0;
		while (charsIn[totalLength] != '\0')
			totalLength++;
		totalLength++; //tack on for the '\0'


					   //Count strings.
		int numStrings = 0;
		for (int n = 0; n < totalLength; n++) {
			if (charsIn[n] == ',')
				numStrings++;
		}
		std::vector<std::string> stringsOut(numStrings);

		//go
		int cur_string_ind = 0;
		int last_comma_ind = 0;

		char temp[100];
		INTEROP_DRIVER::clear_charbuf(temp, 100);

		for (int n = 0; (n + 1) < totalLength; n++) {

			if (charsIn[n] != ',') {
				temp[n - last_comma_ind] = charsIn[n];
			}

			else if (charsIn[n] == ',') {
				temp[n - last_comma_ind] = '\0'; //null-terminate temp.
				stringsOut[cur_string_ind] = temp;
				cur_string_ind++;
				clear_charbuf(temp, 100);
				last_comma_ind = n + 1;
			}
		}
		return stringsOut;
	}
	
	std::vector<double> INTEROP_DRIVER::doublePtrToDoubleVec(double* dptr, int length) {
		std::vector<double> dvec(length);
		for (int n = 0; n < length; n++)
			dvec[n] = dptr[n];

		return dvec;
	}
	std::vector<int> INTEROP_DRIVER::intPtrToIntVec(int* iptr, int length) {
		std::vector<int> ivec(length);
		for (int n = 0; n < length; n++)
			ivec[n] = iptr[n];
		return ivec;
	}
}

extern "C" __declspec(dllexport) char* __stdcall RemoveDevices_GUI(char* path, char* namesToRemove, char* outputPath) {

	//Consistently, what it looks like is that upon loading the dll this works. After closing out, it's all hit or miss
	//from there.
	//I think I want to close / cancel / turn off / free all memory all streams every variable anything ever all of it at the end.
	//I also think I might want to replace all pointer-like references with IntPtrs on my C# end.

	//namesToRemove_LENGTH is the length of the char buffer namesToRemove.
	
	//Calculate path.
	std::string path_string = path;//"C:\\Users\\General_PassivesTest.lbr";
	ELM_GUI_lib::ELM::ReadFileIn(path_string);

	//Calculate namesToRemove.
	std::vector<std::string> nameList_vec = ELM_GUI_lib::INTEROP_DRIVER::charArrayToStringArray(namesToRemove);

	//Remove devices.
	ELM_GUI_lib::ELM::RemoveDevices(nameList_vec);
	
	//Calculate newNamesList.
	std::vector<std::string> newNamesList(ELM_GUI_lib::ELM::numDevices);// { "hihi", "hihi", "asdfasdf", "nvoad" };//
	for (int n = 0; n < ELM_GUI_lib::ELM::numDevices; n++) {
		newNamesList[n] = ELM_GUI_lib::ELM::deviceList[n].name;
	}
	
	//Save result to file.
	std::string out_path_string = outputPath;
	ELM_GUI_lib::ELM::WriteFileOut(out_path_string);
	
	//Calculate newNamesList as output.
	char* newNamesListCharArray = ELM_GUI_lib::INTEROP_DRIVER::stringArrayToCharArray(newNamesList);
	return newNamesListCharArray;

	//File's being removed just fine. 
		//Somewhere in here we have some ugly accumulation of excess XML data.
		//The problem is only when we try to call the "Remove" button >once in the same session.

	//char* returnTestOut_PTR = new char[20];
	//if (x == 0) {
	//	for (int n = 0; n < 20; n++)
	//		returnTestOut_PTR[n] = 'a';
	//}
	//else {
	//	for (int n = 0; n < 20; n++)
	//		returnTestOut_PTR[n] = 'b';
	//}
	//returnTestOut_PTR[19] = '\0';
	//return returnTestOut_PTR;
}

extern "C" __declspec(dllexport) char* __stdcall GetCurrentDeviceNameList_GUI(char* path) {

	//Read file.
	std::string path_string = path;
	ELM_GUI_lib::ELM::ReadFileIn(path_string);

	//Compute currentNameList.
	std::vector<std::string> currentNameList(ELM_GUI_lib::ELM::numDevices);
	for (int n = 0; n < ELM_GUI_lib::ELM::numDevices; n++) {
		currentNameList[n] = ELM_GUI_lib::ELM::deviceList[n].name;
	}

	//Output currentNameListCharArray.
	char* currentNameListCharArray = ELM_GUI_lib::INTEROP_DRIVER::stringArrayToCharArray(currentNameList);
	return currentNameListCharArray;
}

//2xN.
extern "C" __declspec(dllexport) char* __stdcall AddDevice_2xN_GUI(
	char* inputPath,
																	 
	char* d_name,
	char* padNames,
	double space_x, double space_y, double dim_x, double dim_y, int N,

	char* outputPath
)
{
	//Load in.
	std::string inputPath_string = inputPath;
	ELM_GUI_lib::ELM::ReadFileIn(inputPath_string);
	std::string d_name_string = d_name;
	std::vector<std::string> padNames_vec = ELM_GUI_lib::INTEROP_DRIVER::charArrayToStringArray(padNames);
	
	//Call.
	ELM_GUI_lib::ELM::AddDevice_2xN(
		d_name_string, 
		padNames_vec,
		space_x, space_y, dim_x, dim_y, N
	);
	
	//Save the operation result.
	std::string outputPath_string = outputPath;
	ELM_GUI_lib::ELM::WriteFileOut(outputPath_string);
	
	//Get new name list.
	std::vector<std::string> newNamesList(ELM_GUI_lib::ELM::numDevices);// { "hihi", "hihi", "asdfasdf", "nvoad" };//
	for (int n = 0; n < ELM_GUI_lib::ELM::numDevices; n++) {
		newNamesList[n] = ELM_GUI_lib::ELM::deviceList[n].name;
	}
	
	//Return the new namelist.
	char* newNamesListCharArray = ELM_GUI_lib::INTEROP_DRIVER::stringArrayToCharArray(newNamesList);
	return newNamesListCharArray;

	/*
	char* returnTestOut_PTR = new char[20];
		for (int n = 0; n < 20; n++)
			returnTestOut_PTR[n] = 'a';
	returnTestOut_PTR[19] = '\0';
	return returnTestOut_PTR;
	*/
}

//RA.
extern "C" __declspec(dllexport) char* __stdcall AddDevice_RA_GUI(
	char* inputPath,

	char* d_name,
	char* d_padNames,
	double d_REF, int d_N, double d_padW, double d_padL, double d_padSpace,
	double d_centeredSquarePad_DIM,
	double d_cornerSquarePads_REF, double d_cornerSquarePads_DIM,

	char* outputPath
	) {

	//Load file.
	std::string inputPath_string = inputPath;
	ELM_GUI_lib::ELM::ReadFileIn(inputPath_string);
	std::string d_name_string = d_name;
	std::vector<std::string> padNames_vec = ELM_GUI_lib::INTEROP_DRIVER::charArrayToStringArray(d_padNames);

	//Call.
	ELM_GUI_lib::ELM::AddDevice_RA(
		d_name_string,
		padNames_vec,
		d_REF, d_N, d_padW, d_padL, d_padSpace,
		d_centeredSquarePad_DIM,
		d_cornerSquarePads_REF, d_cornerSquarePads_DIM
	);

	//Save the operation result.
	std::string outputPath_string = outputPath;
	ELM_GUI_lib::ELM::WriteFileOut(outputPath_string);

	//Get new name list.
	std::vector<std::string> newNamesList(ELM_GUI_lib::ELM::numDevices);// { "hihi", "hihi", "asdfasdf", "nvoad" };//
	for (int n = 0; n < ELM_GUI_lib::ELM::numDevices; n++) {
		newNamesList[n] = ELM_GUI_lib::ELM::deviceList[n].name;
	}

	//Return the new namelist.
	char* newNamesListCharArray = ELM_GUI_lib::INTEROP_DRIVER::stringArrayToCharArray(newNamesList);
	return newNamesListCharArray;
	
	/*
	char* returnTestOut_PTR = new char[20];
	for (int n = 0; n < 20; n++)
		returnTestOut_PTR[n] = 'a';
	returnTestOut_PTR[19] = '\0';
	return returnTestOut_PTR;
	*/
}

//RxR.
extern "C" __declspec(dllexport) char* __stdcall AddDevice_RxR_GUI(
	char* inputPath,

	char* d_name,
	char* d_padNames,
	int d_N_rows,
	int* d_N_pads, double* d_padX, double* d_padY, double* d_padSpace, //length N_rows
	double* d_horizontalOffset, double* d_verticalOffset, //length N_rows - 1

	char* outputPath
) {
	//Load file.
	std::string inputPath_string = inputPath;
	ELM_GUI_lib::ELM::ReadFileIn(inputPath_string);
	std::string d_name_string = d_name;
	std::vector<std::string> padNames_vec = ELM_GUI_lib::INTEROP_DRIVER::charArrayToStringArray(d_padNames);

	//Call.
	ELM_GUI_lib::ELM::AddDevice_RxR(
		d_name_string,
		padNames_vec,
		d_N_rows,
		d_N_pads, d_padX, d_padY, d_padSpace, //length N_rows
		d_horizontalOffset, d_verticalOffset //length N_rows - 1
	);

	//Save the operation result.
	std::string outputPath_string = outputPath;
	ELM_GUI_lib::ELM::WriteFileOut(outputPath_string);

	//Get new name list.
	std::vector<std::string> newNamesList(ELM_GUI_lib::ELM::numDevices);// { "hihi", "hihi", "asdfasdf", "nvoad" };//
	for (int n = 0; n < ELM_GUI_lib::ELM::numDevices; n++) {
		newNamesList[n] = ELM_GUI_lib::ELM::deviceList[n].name;
	}

	//Return the new namelist.
	char* newNamesListCharArray = ELM_GUI_lib::INTEROP_DRIVER::stringArrayToCharArray(newNamesList);
	return newNamesListCharArray;

	/*
	char* returnTestOut_PTR = new char[20];
	for (int n = 0; n < 20; n++)
	returnTestOut_PTR[n] = 'a';
	returnTestOut_PTR[19] = '\0';
	return returnTestOut_PTR;
	*/
}