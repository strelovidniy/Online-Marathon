using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Sprint_07.Task_06
{
    internal class MyProgram
    {
        public static string CreateGroups(List<Student> students, List<Group> groups)
            => JsonSerializer.Serialize(
                groups.GroupJoin(
                    students,
                    group => group.Name, student => student.GroupName,
                    (group, list) => new
                    {
                        group = group.Name,
                        description = group.Description,
                        rating = list.Average(student => student.Rating),
                        students = list.Select(
                            student => new
                            {
                                FullName = student.Name,
                                AvgMark = student.Rating
                            })
                    }),
                new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    IgnoreNullValues = true
                });
    }
}
