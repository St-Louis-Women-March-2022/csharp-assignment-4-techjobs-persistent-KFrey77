--Part 1
Employers: Id (int), Name (string), Location (string)
Jobs: Id (int), Name (string), EmployerId (int)
Jobskills: JobId (int), SkillId (int)
Skills: Id (int), Name (string), Description (string)

--Part 2
SELECT name
FROM employers
WHERE location = "st. louis city"


--Part 3
SELECT name, description
FROM skills
INNER JOIN jobskills
ON skills.Id = jobskills.SkillId
WHERE name is not null
ORDER BY skills.name ASC
