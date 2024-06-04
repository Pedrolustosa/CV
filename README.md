# Curriculum Generator

![GitHub repo size](https://img.shields.io/github/repo-size/Pedrolustosa/CV)
![GitHub contributors](https://img.shields.io/github/contributors/Pedrolustosa/CV)
![GitHub stars](https://img.shields.io/github/stars/Pedrolustosa/CV?style=social)
![GitHub forks](https://img.shields.io/github/forks/Pedrolustosa/CV?style=social)
[![GitHub license](https://img.shields.io/github/license/Pedrolustosa/CV.svg)](https://github.com/Pedrolustosa/CV/blob/master/LICENSE)

This is a project for generating resumes in PDF format.

## Libraries Used

- **iText**: Library for PDF document manipulation.
- **MediatR**: Library for implementing the Mediator pattern.

## Architecture

The project follows the principles of Clean Architecture, dividing the application into layers according to their responsibilities:

- **Domain**: Contains domain entities and business rules.
- **Application**: Responsible for application logic, including use cases.
- **Infrastructure**: Infrastructure layer, responsible for IoC (Inversion of Control) and other technical details.
- **API (or UI)**: User interface layer or user interface layer.

## Entities

The project includes the following entities:

- **Curriculum**: Represents a resume, containing information such as name, contact, education, experience, and certifications.
- **ContactInfo**: Represents the contact information of an individual, including address, telephone, and email.
- **Education**: Represents the individual's education, including institution, course, state, etc.
- **Experience**: Represents professional experience, including company, position, period, etc.
- **Certification**: Represents a certification obtained by the individual, including name and institution.

## CQRS (Command Query Responsibility Segregation)

The project implements the CQRS standard to separate the concerns of read and write operations. Commands and queries are segregated into separate classes, and corresponding handlers are implemented to perform these actions. 
<br>
**NOTE: In this case I'm just using the idea of creation to generate the PDF of your resume**

## How to Use

1. Clone the repository.
2. Run the project.

## JSON Example for testing

```json
{
  "name": "John Doe",
  "contact": {
    "address": "123 Main St",
    "telephone": "555-1234",
    "email": "john.doe@example.com",
    "gitHub": "https://github.com/johndoe",
    "linkedIn": "https://linkedin.com/in/johndoe"
  },
  "education": [
    {
      "institution": "University of Example",
      "city": "Exampleville",
      "state": "CA",
      "course": "Computer Science",
      "status": "Graduated",
      "period": "2010 - 2014"
    },
    {
      "institution": "Business School",
      "city": "Business City",
      "state": "CA",
      "course": "Business Administration",
      "status": "Graduated",
      "period": "2005 - 2009"
    }
  ],
  "experience": [
    {
      "company": "Tech Solutions Inc.",
      "city": "Tech Town",
      "position": "Software Developer",
      "period": "2015 - Present",
      "description": [
        "Developed new features for web applications.",
        "Performed code reviews and provided feedback to team members."
      ]
    },
    {
      "company": "Finance Systems Ltd.",
      "city": "Finance City",
      "position": "Senior Developer",
      "period": "2010 - 2015",
      "description": [
        "Led a team of developers in the implementation of a new financial system.",
        "Optimized database queries for improved performance."
      ]
    }
  ],
  "certification": [
    {
      "name": "Certified Web Developer",
      "institution": "Web Development Institute"
    },
    {
      "name": "Project Management Professional (PMP)",
      "institution": "Project Management Institute"
    }
  ]
}
```
## Contribution

Contributions are welcome! Feel free to open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
