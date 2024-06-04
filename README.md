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
    "email": "john.doe@example.com"
  },
  "education": [
    {
      "institution": "University of Example",
      "course": "Computer Science",
      "city": "Exampleville",
      "state": "CA",
      "status": "Graduated",
      "period": "2010 - 2014"
    }
  ],
  "experience": [
    {
      "company": "Tech Solutions Inc.",
      "position": "Software Developer",
      "city": "Tech Town",
      "period": "2015 - Present",
      "description": [
        "Developed new features for web applications.",
        "Performed code reviews and provided feedback to team members."
      ]
    }
  ],
  "certifications": [
    {
      "name": "Certified Web Developer",
      "institution": "Web Development Institute"
    }
  ]
}
```
## Contribution

Contributions are welcome! Feel free to open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
