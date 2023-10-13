#include <iostream>
#include <string>
#include <format>
#include <algorithm>

#define get_name(x) #x

using namespace std;

std::string lower(std::string s){
    std::transform(s.begin(), s.end(), s.begin(), [](unsigned char c){ return std::tolower(c); });
    return s;
}

template<class T>
class ValidInputs {
 private:
    static T CmdInput(bool hasAMin, bool hasAMax, bool strict, T min, T max, string restriction) {
        bool allIsFine;
        T answer;
        string cmdInput;
        string errorMessage;
        string specifiedRestriction = restriction.length() == 0 ? "" : "Restriction! Your value must " + restriction;

        std::cout << "Please enter a value. " + specifiedRestriction << std::endl;
        
        do {
            errorMessage = "";
            try {
                std::cin >> answer;
                if (hasAMin || hasAMax) {
                    bool tooSmall = strict ? answer <= min : answer < min;
                    bool tooBig = strict ? answer >= max : answer > max;
                    if (hasAMin && hasAMax) {
                        if (tooSmall || tooBig) errorMessage = specifiedRestriction;
                    }
                    else if (hasAMin) {
                        if (tooSmall) errorMessage = specifiedRestriction;
                    }
                    else if (tooBig) {
                        errorMessage = specifiedRestriction;
                    }
                }
            }
            catch(const std::exception& e) {
                // std::cerr << e.what() << '\n';
                errorMessage = "Your value is not valid!";
            }

            allIsFine = errorMessage.length() == 0;
            if(!allIsFine) {
                errorMessage += " Please retry: ";
                std::cout << errorMessage << std::endl;
            }
        } while (!allIsFine);
        return answer;
    }
 public:
    static T CMDInput(){
        return ValidInputs<T>().CmdInput(false, false, false, 0, 0, "");
    }

    static T CMDInputGreaterThan(T minimumValue){
        return ValidInputs<T>().CmdInput(true, false, true, minimumValue, 0, std::format("be strictly superior than {}.", minimumValue));
    }

    static T CMDInputAtLeast(T minValue){
        return ValidInputs<T>().CmdInput(true, false, false, minValue, 0, std::format("be at least {}.", minValue));
    }

    static T CMDInputSmallerThan(T maximumValue){
        return ValidInputs<T>().CmdInput(false, true, true, 0, maximumValue, std::format("be strictly inferior than {}.", maximumValue));
    }

    static T CMDInputAtMost(T maxValue){
        return ValidInputs<T>().CmdInput(false, true, false, 0, maxValue, std::format("be at most {}.", maxValue));
    }

    static T CMDInputBetween(T minimumBorn, T maximumBorn){
        return ValidInputs<T>().CmdInput(true, true, true, minimumBorn, maximumBorn, std::format("be between {} and {}.", minimumBorn, maximumBorn));
    }

    static T CMDInputFromA(T minimumBorn, T maximumBorn){
        return ValidInputs<T>().CmdInput(true, true, false, minimumBorn, maximumBorn, std::format("be between {} and {} inclusively.", minimumBorn, maximumBorn));
    }

    static T CMDInputPositiveOrNul(){
        return CMDInputAtLeast(0);
    }

    static T CMDInputStrictlyPositive(){
        return CMDInputGreaterThan(0);
    }

    static T CMDInputNegativeOrNul(){
        return CMDInputAtMost(0);
    }

    static T CMDInputStrictlyNegative(){
        return CMDInputSmallerThan(0);
    }

    static bool CMDInputAnswer(string question){
        bool allIsFine;
        bool answerIsYes = true;
        string errorMessage;
        string cmdInput;
        char firstCharacter;

        std::cout << question + " (Y/n)? " << std::endl;
        do {
            errorMessage = "";
            std::cin >> cmdInput;
            if (cmdInput.length() == 1) {
                firstCharacter = lower(cmdInput)[0];
                answerIsYes = firstCharacter == 'y';
                if (!answerIsYes && (firstCharacter != 'n')) errorMessage = "Your answer must be 'y' or 'n'. (Uppercase allowed)";
            }
            else {
                errorMessage = "A valid input in this case only implies one character, either the first of 'yes' or 'no'.";
            }

            allIsFine = errorMessage.length() == 0;
            if (!allIsFine) {
                errorMessage += " Please restart: ";
                std::cout << errorMessage << std::endl;
            }
        } while (!allIsFine);
        return answerIsYes;
    }
};

