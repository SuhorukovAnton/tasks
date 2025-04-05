namespace Task1.Dto;

public record class DataDto(int Code, string Value);

public record class FullDataDto(int Id, int Code, string Value) : DataDto(Code, Value);
