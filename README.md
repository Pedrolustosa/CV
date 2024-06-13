# Curriculum Generator

![GitHub repo size](https://img.shields.io/github/repo-size/Pedrolustosa/CV)
![GitHub contributors](https://img.shields.io/github/contributors/Pedrolustosa/CV)
![GitHub stars](https://img.shields.io/github/stars/Pedrolustosa/CV?style=social)
![GitHub forks](https://img.shields.io/github/forks/Pedrolustosa/CV?style=social)
[![GitHub license](https://img.shields.io/github/license/Pedrolustosa/CV.svg)](https://github.com/Pedrolustosa/CV/blob/master/LICENSE)

This is a project for generating resumes in PDF format.

## Libraries Used

- **QuestPDF**: Library for generating PDF documents. (Version: 2024.6.0)
- **MediatR**: Library for implementing the Mediator pattern. (Version: 11.1.0)
- **MediatR.Extensions.Microsoft.DependencyInjection**: Extensions for integrating MediatR with Microsoft.Extensions.DependencyInjection. (Version: 11.1.0)
- **Swashbuckle.AspNetCore**: Library for generating Swagger/OpenAPI documentation for ASP.NET Core Web APIs. (Version: 6.4.0)
- **Microsoft.Extensions.Configuration.Abstractions**: Provides interfaces for accessing configuration settings in ASP.NET Core applications. (Version: 8.0.0)

## Architecture

The project follows the principles of Clean Architecture, dividing the application into layers according to their responsibilities:

- **Domain**: Contains domain entities and business rules.
- **Application**: Responsible for application logic, including use cases.
- **Infrastructure**: Infrastructure layer, responsible for IoC (Inversion of Control) and other technical details.
- **API (or UI)**: User interface layer or user interface layer.

## Entities

The project includes the following entities:

- **Certification**: Represents a certification obtained by the individual, including name, year, and issuer.
- **Contact**: Represents the contact information of an individual, including full name, email, phone, address, GitHub, and LinkedIn.
- **Education**: Represents the individual's education, including degree, institution, city, state, start date, and end date.
- **WorkExperience**: Represents professional work experience, including job title, company, city, state, start date, end date, description, and technologies.
- **Curriculum**: Represents a resume, containing contact information, education, work experience, and certifications.

## CQRS (Command Query Responsibility Segregation)

The project implements the CQRS standard to separate the concerns of read and write operations. Commands and queries are segregated into separate classes, and corresponding handlers are implemented to perform these actions.

## How to Use

1. Clone the repository.
2. Run the project.

## Example JSON

```json
{
  "contact": {
    "fullName": "John Doe",
    "email": "john.doe@example.com",
    "phone": "+1-800-555-1234",
    "address": "123 Main St, Springfield, USA",
    "gitHub": "https://github.com/johndoe",
    "linkedIn": "https://www.linkedin.com/in/johndoe"
  },
  "educations": [
    {
      "degree": "Bachelor of Science in Computer Science",
      "institution": "Springfield University",
      "city": "Springfield",
      "state": "IL",
      "startDate": 2015,
      "endDate": 2019
    },
    {
      "degree": "Master of Science in Artificial Intelligence",
      "institution": "Tech Valley Institute",
      "city": "Tech Valley",
      "state": "CA",
      "startDate": 2019,
      "endDate": 2021
    },
    {
      "degree": "Ph.D. in Machine Learning",
      "institution": "Data Science University",
      "city": "Data City",
      "state": "NY",
      "startDate": 2021,
      "endDate": 2025
    }
  ],
  "workExperiences": [
    {
      "jobTitle": "Software Engineer",
      "company": "Innovative Tech Solutions",
      "city": "Springfield",
      "state": "IL",
      "startDate": "2019-07-01T00:00:00Z",
      "endDate": "2024-06-30T00:00:00Z",
      "description": "Developed and maintained various web applications using modern frameworks and technologies.",
      "technologies": ["JavaScript", "React", "Node.js", "MongoDB"]
    },
    {
      "jobTitle": "Data Scientist",
      "company": "AI Labs",
      "city": "Tech Valley",
      "state": "CA",
      "startDate": "2024-07-01T00:00:00Z",
      "endDate": "2027-06-30T00:00:00Z",
      "description": "Performed data analysis and machine learning modeling for various projects.",
      "technologies": ["Python", "TensorFlow", "Scikit-learn", "PyTorch"]
    }
  ],
  "certifications": [
    {
      "name": "Certified Kubernetes Administrator",
      "year": 2022,
      "issuer": "The Linux Foundation"
    },
    {
      "name": "AWS Certified Solutions Architect",
      "year": 2023,
      "issuer": "Amazon Web Services"
    },
    {
      "name": "Microsoft Certified: Azure Developer Associate",
      "year": 2021,
      "issuer": "Microsoft"
    },
    {
      "name": "Certified Scrum Master",
      "year": 2020,
      "issuer": "Scrum Alliance"
    },
    {
      "name": "Google Professional Data Engineer",
      "year": 2024,
      "issuer": "Google Cloud"
    }
  ]
}
```

## Contribution

Contributions are welcome! Feel free to open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
