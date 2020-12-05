<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main() {
	var values = File.ReadLines(@"c:\Users\willt\My Dropbox\Programming\AoC2020\Day 1\input_full.txt").Select(int.Parse).ToList();
	for (int i = 0; i < values.Count; i++) {
		for (int j = i; j < values.Count; j++) {
			for (int k = 0; k < values.Count; k++) {
				if (values[i] + values[j] + values[k] == 2020) {
					Console.WriteLine(values[i] * values[j] * values[k]);
				}
			}
		}
	}
}

