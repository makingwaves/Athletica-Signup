using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Backend.MockApiDtos;
using Backend.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Backend.Data
{
  public class ApiRetriever
  {
    private static readonly HttpClient client = new HttpClient();
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public ApiRetriever(IMapper mapper, IConfiguration configuration)
    {
      _mapper = mapper;
      _configuration = configuration;
      if (client.BaseAddress == null)
      {
        client.BaseAddress = new System.Uri(_configuration["MockDomain"]);
      }
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/users");
      try
      {
        response.EnsureSuccessStatusCode();
        var userReadDtos = await response.Content.ReadAsAsync<IEnumerable<UserReadDto>>();
        return _mapper.Map<IEnumerable<User>>(userReadDtos);
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
        return null;
      }
    }

    public async Task<User> GetUserById(int id)
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/users/{id}");
      try
      {
        response.EnsureSuccessStatusCode();
        var userReadDto = await response.Content.ReadAsAsync<UserReadDto>();
        return _mapper.Map<User>(userReadDto);
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
        return null;
      }
    }

    public async Task<IEnumerable<Contract>> GetContracts()
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/contracts");
      try
      {
        response.EnsureSuccessStatusCode();
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
        return null;
      }
      if (response.StatusCode == HttpStatusCode.OK)
      {
        var contractReadDtos = await response.Content.ReadAsAsync<IEnumerable<ContractReadDto>>();
        return _mapper.Map<IEnumerable<Contract>>(contractReadDtos);
      }
      return null;
    }

    public async Task<IEnumerable<LearningInstitution>> GetLearningInstitutions()
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/learninginstitutions");
      try
      {
        response.EnsureSuccessStatusCode();
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
        return null;
      }
      if (response.StatusCode == HttpStatusCode.OK)
      {
        var instReadDtos = await response.Content.ReadAsAsync<IEnumerable<LearningInstitutionReadDto>>();
        return _mapper.Map<IEnumerable<LearningInstitution>>(instReadDtos);
      }
      return null;
    }

    public async Task<LearningInstitution> GetLearningInstitutionById(int id)
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/learninginstitutions/{id}");
      try
      {
        response.EnsureSuccessStatusCode();
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
        return null;
      }
      var instReadDto = await response.Content.ReadAsAsync<LearningInstitutionReadDto>();
      return _mapper.Map<LearningInstitution>(instReadDto);
    }

    public async Task<IEnumerable<Membership>> GetAllMemberships()
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/memberships");
      try
      {
        response.EnsureSuccessStatusCode();
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
        return null;
      }
      var membershipReadDtos = await response.Content.ReadAsAsync<IEnumerable<MembershipReadDto>>();
      return _mapper.Map<IEnumerable<Membership>>(membershipReadDtos);
    }

    public async Task<IEnumerable<BrisUser>> GetBrisUsers()
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/brisusers");
      try
      {
        response.EnsureSuccessStatusCode();
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
        return null;
      }
      if (response.StatusCode == HttpStatusCode.OK)
      {
        var brisUserReadDtos = await response.Content.ReadAsAsync<IEnumerable<BrisUserReadDto>>();
        return _mapper.Map<IEnumerable<BrisUser>>(brisUserReadDtos);
      }
      return null;
    }

    public async Task<User> CreateUser(User user)
    {
      var userToCreate = _mapper.Map<UserCreateDto>(user);

      var response = await client.PostAsJsonAsync($"{client.BaseAddress}/mock/users", userToCreate);
      try
      {
        response.EnsureSuccessStatusCode();
        var userDtoFromDB = await response.Content.ReadAsAsync<UserReadDto>();
        return _mapper.Map<User>(userDtoFromDB);
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
      }
      return null;
    }

    public async Task<IEnumerable<Facility>> GetAllFacilities()
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/facilities");
      try
      {
        response.EnsureSuccessStatusCode();
        var facilities = await response.Content.ReadAsAsync<IEnumerable<FacilityReadDto>>();
        return _mapper.Map<IEnumerable<Facility>>(facilities);
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
      }
      return null;
    }

    public async Task<Contract> GetContractById(int id)
    {
      var response = await client.GetAsync($"{client.BaseAddress}/mock/contracts/{id}");
      try
      {
        response.EnsureSuccessStatusCode();
        var contract = await response.Content.ReadAsAsync<ContractReadDto>();
        return _mapper.Map<Contract>(contract);
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
      }
      return null;
    }

    public async Task<Membership> CreateMembership(Membership membership)
    {
      var membershipCreateDto = _mapper.Map<MembershipCreateDto>(membership);
      var response = await client.PostAsJsonAsync($"{client.BaseAddress}/mock/memberships", membershipCreateDto);
      try
      {
        response.EnsureSuccessStatusCode();
        var membershipReadDto = await response.Content.ReadAsAsync<MembershipReadDto>();
        return _mapper.Map<Membership>(membershipReadDto);
      }
      catch (HttpRequestException)
      {
        Console.WriteLine(response.StatusCode);
      }
      return null;
    }

    public async Task<bool> PartialUserUpdate(int id, JsonPatchDocument<ClientDtos.UserUpdateDto> patchDoc)
    {
      var response = await client.PatchAsync($"{client.BaseAddress}/mock/users/{id}", new StringContent(JsonConvert.SerializeObject(patchDoc), Encoding.UTF8, "application/json-patch+json"));
      try
      {
        response.EnsureSuccessStatusCode();
        return true;
      }
      catch (HttpRequestException)
      {
        System.Console.WriteLine(response.StatusCode);
        return false;
      }
    }

  }
}