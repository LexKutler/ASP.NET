﻿using MedprCore.DTO;

namespace MedprCore.Abstractions
{
    public interface IFamilyService
    {
        Task<List<FamilyDTO>> GetFamiliesByPageNumberAndPageSizeAsync
            (int pageNumber, int pageSize);

        Task<FamilyDTO> GetFamiliesByIdAsync(Guid id);

        Task<List<FamilyDTO>> GetAllFamiliesAsync();
        Task<int> CreateFamilyAsync(FamilyDTO dto);
        Task<int> PatchFamilyAsync(Guid id, List<PatchModel> patchList);
        Task<int> DeleteFamilyAsync(FamilyDTO dto);
    }
}