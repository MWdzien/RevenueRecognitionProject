namespace RevenueRecognitionProject.Services.ClientsServices;

public class ClientsService : IClientsService
{
    private readonly IClientsRepository _clientsRepository;

    public ClientsService(IClientsRepository clientsRepository)
    {
        _clientsRepository = clientsRepository;
    }

    public async Task AddIndividualClient(AddIndividualClientDTO addIndividualClientDto)
    {
        IndividualClient? individualClient = await _clientsRepository.GetIndividualClientByPesel(addIndividualClientDto.PESEL);

        DoesClientWithPeselExist(individualClient);

        var newIndividualClient = new IndividualClient()
        {
            FirstName = addIndividualClientDto.FirstName,
            LastName = addIndividualClientDto.LastName,
            Adress = addIndividualClientDto.Adress,
            PhoneNumber = addIndividualClientDto.PhoneNumber,
            Email = addIndividualClientDto.Email,
            PESEL = addIndividualClientDto.PESEL
        };
        
        await _clientsRepository.AddIndividualClient(newIndividualClient);
    }
    
    public async Task DeleteIndividualClient(int individualClientId)
    {
        IndividualClient? individualClient = await _clientsRepository.GetIndividualClientById(individualClientId);
        DoesClientWithIdExist(individualClient, individualClientId);

        await _clientsRepository.DeleteIndividualClient(individualClient);
    }


    public async Task UpdateIndividualClient(int individualClientId, UpdateIndividualClientDTO updateIndividualClientDto)
    {
        IndividualClient? individualClient = await _clientsRepository.GetIndividualClientById(individualClientId);
        DoesClientWithIdExist(individualClient, individualClientId);

        await _clientsRepository.UpdateIndividualClient(individualClient, updateIndividualClientDto);
    }

    public async Task AddCompanyClient(AddCompanyClientDTO addCompanyClientDto)
    {
        CompanyClient? companyClient = await _clientsRepository.GetCompanyClientByKRS(addCompanyClientDto.KRSNumber);
        DoesClientWithKRSExist(companyClient);

        var newCompanyClient = new CompanyClient()
        {
            Name = addCompanyClientDto.Name,
            Adress = addCompanyClientDto.Adress,
            Email = addCompanyClientDto.Email,
            PhoneNumber = addCompanyClientDto.PhoneNumber,
            KRSNumber = addCompanyClientDto.KRSNumber
        };

        await _clientsRepository.AddCompanyClient(newCompanyClient);
    }

    public async Task UpdateCompanyClient(int companyClientId, UpdateCompanyClientDTO updateCompanyClientDto)
    {
        CompanyClient? companyClient = await _clientsRepository.GetCompanyClientById(companyClientId);
        DoesCompanyClientWithIdExist(companyClient, companyClientId);

        await _clientsRepository.UpdateCompanyClient(companyClient, updateCompanyClientDto);
    }

    public void DoesClientWithPeselExist(IndividualClient? individualClient)
    {
        if (individualClient != null)
            throw new Exception($"Client with PESEL: {individualClient.PESEL} already exists");
        
    }

    public void DoesClientWithIdExist(IndividualClient? individualClient, int individualClientId)
    {
        if (individualClient == null)
            throw new Exception($"Client with ID: {individualClientId} does not exist");
        
    }

    public void DoesClientWithKRSExist(CompanyClient? companyClient)
    {
        if (companyClient != null)
            throw new Exception($"Client with KRS: {companyClient.KRSNumber} already exists");
        
    }

    public void DoesCompanyClientWithIdExist(CompanyClient? companyClient, int companyClientId)
    {
        if (companyClient == null)
            throw new Exception($"Client with ID: {companyClientId} does not exist");
    }
}