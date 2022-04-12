import Student from "./student.model";

export default interface School {
    id: number,
    name: string,
    students : Student[]
}