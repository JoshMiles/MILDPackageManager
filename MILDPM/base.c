#include <stdio.h>
#include <string.h>

void printUsage(){
	printf("Usage:\n\
		\t-v, --version\t:Print the version Number\n\
		\t-h, --help\t:Print this help\n");
}

int main (int argc, char *argv[]){
	if (argc < 2){
		printf("Error, no argument given\n");
		printUsage();
		return 1;
	} else {
		int strCompLimit = 15;
		int strCompVersion = strncmp(argv[1],"--version",strCompLimit);
		int strCompV = strncmp(argv[1],"-v",strCompLimit);
		int strCompHelp = strncmp(argv[1],"--help",strCompLimit);
		int strCompH = strncmp(argv[1],"-h",strCompLimit);
		if (strCompV == 0 || strCompVersion == 0) {
			printf("MILD Package Manager: Version 0.01a\n");
			return 0;
		} else if (strCompHelp == 0 || strCompH == 0){
			printUsage();
			return 0;
		} else {
			printf("Argument\"%s\" not found\n", argv[1]);
			printUsage();
			return 1;
		}
	}
}
