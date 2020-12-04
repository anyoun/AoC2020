<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main() {
	int valid = 0;
	int invalid = 0;
	var currentRecordFields = new Dictionary<string, string>();
	foreach (var line in File.ReadLines(@"c:\Users\willt\My Dropbox\Programming\aoc2020\Day 4\input.txt")) {
		if (String.IsNullOrWhiteSpace(line)) {
			// new record
			if (IsValid(currentRecordFields))
				valid++;
			else
				invalid++;
			currentRecordFields.Clear();
		}
		foreach (var record in line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)) {
			var a = record.Split(':');
			currentRecordFields.Add(a[0], a[1]);
		}
	}

	if (IsValid(currentRecordFields))
		valid++;
	else
		invalid++;

	String.Format("Found {0} valid, {1} invalid.", valid, invalid).Dump();
}

HashSet<string> required = new HashSet<string>{
		"byr",
		"iyr",
		"eyr",
		"hgt",
		"hcl",
		"ecl",
		"pid",
	};
Dictionary<string, Func<string, bool>> validators = new Dictionary<string, Func<string, bool>> {
		{"byr", IsValidBirthYear},
		{"iyr", IsValidIssueYear},
		{"eyr", IsValidExpirationYear},
		{"hgt", IsValidHeight},
		{"hcl", IsValidHair},
		{"ecl", IsValidEye},
		{"pid", IsValidPid},
		{"cid", _ => true},
	};

static bool IsValidBirthYear(string v) {
	int r;
	if(!Int32.TryParse(v, out r)) return false;
	return 1920 <= r && r <= 2002;
}

static bool IsValidIssueYear(string v) {
	int r;
	if (!Int32.TryParse(v, out r)) return false;
	return 2010 <= r && r <= 2020;
}

static bool IsValidExpirationYear(string v) {
	int r;
	if (!Int32.TryParse(v, out r)) return false;
	return 2020 <= r && r <= 2030;
}

static bool IsValidHeight(string v) {
	var m = System.Text.RegularExpressions.Regex.Match(v, @"^(\d+)(cm|in)$");
	if (!m.Success) return false;
	int r;
	if (!Int32.TryParse(m.Groups[1].Value, out r)) return false;
	if(m.Groups[2].Value == "cm"){
		return 150 <= r && r<= 193;
	} else {
		return 59 <= r && r <= 76;
	}
}

static bool IsValidHair(string v) {
	return System.Text.RegularExpressions.Regex.Match(v, @"^#[0-9a-f]{6}$").Success;
}

static HashSet<string> eyeColors = new HashSet<string>{"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
static bool IsValidEye(string v) {
	return eyeColors.Contains(v);
}
static bool IsValidPid(string v) {
	return System.Text.RegularExpressions.Regex.Match(v, @"^\d{9}$").Success;
}


bool IsValid(Dictionary<string, string> record) {
	if(required.Except(record.Keys).Any())
		return false;
	return record.All(r => /*!validators.ContainsKey(r.Key) || */validators[r.Key](r.Value));
}