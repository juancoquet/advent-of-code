// X lose
// Y draw
// Z win
// win 6
// draw 3
// loss 0
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.Files;
import java.io.IOException;
import java.util.HashMap;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        // how many points if strat guide is followed?
        HashMap<Character, Integer> points = new HashMap<>();
        points.put('A', 1);
        points.put('B', 2);
        points.put('C', 3);
        HashMap<Integer, Character> mySel = new HashMap<>();
        mySel.put(1, 'A');
        mySel.put(2, 'B');
        mySel.put(3, 'C');
        // to lose, -1 (+2) % 3
        // to win, +1 % 3
        
        int total = 0;
        Path file = Paths.get("input.txt");
        try {
            List<String> lines = Files.readAllLines(file);
            for (String line : lines) {
                char elf = line.charAt(0);
                char me = line.charAt(2);
                if (me == 'Y') { // draw
                    total += points.get(elf) + 3;
                } else if (me == 'X') { // loss
                    int pickVal = points.get(elf) + 2;
                    if (pickVal > 3) { pickVal %= 3; }
                    char myPick = mySel.get(pickVal);
                    total += points.get(myPick);
                } else { // win
                    int pickVal = points.get(elf) + 1;
                    if (pickVal > 3) { pickVal %= 3; }
                    char myPick = mySel.get(pickVal);
                    total += points.get(myPick) + 6;
                }
            }
            System.out.println(total);
        } catch (IOException e) {
            System.out.println("error reading file");
            System.out.println(e.getMessage());
        }
    }
}
