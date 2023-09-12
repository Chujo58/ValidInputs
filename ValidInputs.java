import java.util.Scanner;

public class ValidInputs{
    private static int IntCmdInput(boolean hasAMin, boolean hasAMax, boolean strict, int min, int max, String restriction){
        Scanner scan = new Scanner(System.in);
        boolean allIsFine;
        int answer = 0;
        String CmdInput;
        String errorMessage;
        String specifiedRestriction = restriction.length() == 0 ? "" : "Restriction! Your int must " + restriction;

        System.out.println("Please enter an integer. " + specifiedRestriction);

        do {
            errorMessage = "";
            CmdInput = scan.nextLine();
            try {
                answer = Integer.parseInt(CmdInput);
                if (hasAMin || hasAMax) {
                    boolean tooSmall = strict ? answer <= min : answer < min;
                    boolean tooBig = strict ? answer >= max : answer > max;
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
            catch(Exception e) {
                errorMessage = "Your int is not valid.";
            }

            allIsFine = errorMessage.length() == 0;
            if (!allIsFine) {
                errorMessage += " Please retry: ";
                System.out.println(errorMessage);
            }
        } while (!allIsFine);
        scan.close();
        return answer;
    }

    public static int IntCMDInput() {
        return IntCmdInput(false, false, false, 0, 0, "");
    }

    public static int IntCMDInputGreaterThan(int minimumValue) {
        return IntCmdInput(true, false, true, minimumValue, 0, String.format("be strictly superior than %s.", minimumValue));
    }

    public static int IntCMDInputAtLeast(int minValue) {
        return IntCmdInput(true, false, false, minValue, 0, String.format("be at least %s.",minValue));
    }

    public static int IntCMDInputSmallerThan(int maximumValue) {
        return IntCmdInput(false, true, true, 0, maximumValue, String.format("be strictly inferior than %s.",maximumValue));
    }

    public static int IntCMDInputAtMost(int maxValue) {
        return IntCmdInput(false, true, false, 0, maxValue, String.format("be at most %s.",maxValue));
    }

    public static int IntCMDInputBetween(int minimumBorn, int maximumBorn) {
        return IntCmdInput(true, true, true, minimumBorn, maximumBorn, String.format("be between %1$s and %2$s.", minimumBorn, maximumBorn));
    }

    public static int IntCMDInputFromA(int minimumBorn, int maximumBorn) {
        return IntCmdInput(true, true, false, minimumBorn, maximumBorn, String.format("be between %1$s and %2$s inclusively.", minimumBorn, maximumBorn));
    }

    public static int IntCMDInputPositiveOrNul() {
        return IntCMDInputAtLeast(0);
    }

    public static int IntCMDInputStrictlyPositive() {
        return IntCMDInputGreaterThan(0);
    }

    public static int IntCMDInputNegativeOrNul() {
        return IntCMDInputAtMost(0);
    }

    public static int IntCMDInputStrictlyNegative() {
        return IntCMDInputSmallerThan(0);
    }

    public static boolean CMDInputAnswerYesNo(String yesNoQuestion){
        Scanner scan = new Scanner(System.in);
        boolean allIsFine;
        boolean answerIsYes = true;
        String errorMessage, CmdInput;
        char firstChar;
        System.out.print(yesNoQuestion + "(Y/n)? ");
        do {
            errorMessage = "";
            CmdInput = scan.nextLine();
            if (CmdInput.length() == 1) {
                firstChar = CmdInput.toLowerCase().charAt(0);
                answerIsYes = firstChar == 'y';
                if (!answerIsYes && (firstChar != 'n')) errorMessage = "Your answer must be 'y' or 'n'. (Uppercase allowed)";
            }
            else {
                errorMessage = "A valid input in this case only implies one caracter, either the first of 'yes' or 'no'.";
            }
            
            allIsFine = errorMessage.length() == 0;

            if (!allIsFine) {
                errorMessage += " Please restart: ";
                System.out.println(errorMessage);
            }
        } while (!allIsFine);
        scan.close();
        return answerIsYes;
    }

}