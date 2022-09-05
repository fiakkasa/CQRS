using SimpleSingleProject.Models;

namespace SimpleSingleProject.Dtos;

public record BookInputDto(
    string Title,
    string ISBN,
    long Pages,
    PublicationType PublicationType
);
