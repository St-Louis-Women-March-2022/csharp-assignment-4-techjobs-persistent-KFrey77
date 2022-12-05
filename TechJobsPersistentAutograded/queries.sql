--Part 1

--Part 2

--Part 3
SELECT name, description
FROM skills
INNER JOIN jobskills
ON skills.Id = jobskills.SkillId
WHERE name is not null
ORDER BY skills.name ASC
