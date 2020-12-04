<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main() {
	int valid = 0;
	int invalid = 0;
	var required = new HashSet<string>{
	"byr",
"iyr",
"eyr",
"hgt",
"hcl",
"ecl",
"pid",	
	};
	var currentRecordFields = new HashSet<string>();
	foreach(var line in File.ReadLines(@"c:\Users\willt\My Dropbox\Programming\aoc2020\Day 4\input.txt")){
		if(String.IsNullOrWhiteSpace(line)){
			// new record
			if (required.Except(currentRecordFields).Any()) {
			  invalid++;
			} else {
			valid++;
			}
			currentRecordFields.Clear();
		}
		foreach (var record in line.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)){
			var a = record.Split(':');
			var key = a[0];
			currentRecordFields.Add(key);
		}
	}

	if (required.Except(currentRecordFields).Any()) {
		invalid++;
	} else {
		valid++;
	}

	String.Format("Found {0} valid, {1} invalid.", valid, invalid).Dump();
}

// Define other methods and classes here
