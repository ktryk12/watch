using Reporting_Microservice.Modellayer;
using Reporting_Microservice.Dto;

namespace Reporting_Microservice.DtoConverter
{
    public static class ReportingConverter
    {
        // Konverterer til DTO fra entitet
        public static ReportingDto ToDto(Reporting reporting)
        {
            return new ReportingDto
            {
                ReportId = reporting.ReportId,
                Period = reporting.Period,
                Type = reporting.Type,
                EmployeeId = reporting.EmployeeId
            };
        }


        // Opdaterer en eksisterende Reporting entitet fra DTO (inklusiv ReportId) til brug ved opdatering
        public static Reporting FromDtoForUpdate(int reportId, ReportingDto reportingDto)
        {
            return new Reporting
            {
                ReportId = reportId, // Sæt ReportId baseret på den eksisterende entitets ID
                Period = reportingDto.Period,
                Type = reportingDto.Type,
                EmployeeId = reportingDto.EmployeeId
            };
        }

        // Opretter en ny Reporting entitet fra DTO (uden ReportId) til brug ved oprettelse
        public static Reporting ToEntityForCreation(CreateReportingDto dto)
        {
            return new Reporting
            {
                Period = dto.Period,
                Type = dto.Type,
                EmployeeId = dto.EmployeeId
            };
        }
    }
}
