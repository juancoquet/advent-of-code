import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.Files;
import java.io.IOException;
import java.util.List;
import java.util.PriorityQueue;

public class Main {
    public static void main(String[] args) {
        Path file = Paths.get("input.txt");
        int curr = 0;
        try {
            List<String> lines = Files.readAllLines(file);
            PriorityQueue<Integer> heap = new PriorityQueue<>();
            for (String line : lines) {
                if (line.isEmpty()) { 
                    heap.add(curr);
                    if (heap.size() > 3) { heap.poll(); }
                    curr = 0;
                    continue;
                }
                int cals = Integer.parseInt(line);
                curr += cals;
            }
            int total = 0;
            for (int i=0; i<3; i++) { total += heap.poll(); }
            System.out.println(total);
        } catch (IOException e) {
            System.out.println("error reading file");
            System.out.println(e.getMessage());
        }
    }
}
