namespace RevenueRecognitionProject.Services.ClientsServices;

public interface IClientsService
{
    //metoda AddIndividualClient, AddCompanyClient, UpdateIndividualClient, UpdateCompanyClient, RemoveIndividualClient
    public Task AddIndividualClient(AddIndividualClientDTO addIndividualClientDto);
    public Task DeleteIndividualClient(int individualClientId);
    public Task UpdateIndividualClient(int individualClientId, UpdateIndividualClientDTO updateIndividualClientDto);
    public Task AddCompanyClient(AddCompanyClientDTO addCompanyClientDto);
    public Task UpdateCompanyClient(int companyClientId, UpdateCompanyClientDTO updateCompanyClientDto);
    public void DoesClientWithPeselExist(IndividualClient? individualClient);
    public void DoesClientWithIdExist(IndividualClient? individualClient, int individualClientId);
    public void DoesClientWithKRSExist(CompanyClient? companyClient);
    public void DoesCompanyClientWithIdExist(CompanyClient? companyClient, int companyClientId);
}