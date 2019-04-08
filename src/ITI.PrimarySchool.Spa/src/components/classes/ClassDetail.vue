<template>
  <div class="mb-4">
    <h1>Detail of the {{container.name}} class</h1>
    <div>
      <table class="table table-striped table-hover table-bordered">
        <thead>
          <tr>
            <th colspan="2">Level :</th>
            <th colspan="2">{{container.level}}</th>
          </tr>
          <tr>
            <th>Teacher firstname :</th>
            <td v-if="container.teacher.teacherFirstName == '' ">/</td>
            <td v-else>{{container.teacher.teacherFirstName}}</td>
            <th>Teacher lastname :</th>
            <td v-if="container.teacher.teacherLastName == '' ">/</td>
            <td v-else>{{container.teacher.teacherLastName}}</td>
          </tr>
          <tr>
            <td colspan="4" height="10px"></td>
          </tr>
        </thead>
        <tbody>
          <tr aria-colspan="3">
            <th>Student ID</th>
            <th>Student firstname</th>
            <th colspan="2">Student lastname</th>
          </tr>
          <tr v-if="container.students.length == 0 || container.students[0].studentId == 0">
            <td colspan="4" class="text-center">Il n'y a actuellement aucun élève.</td>
          </tr>
          <tr v-else v-for="student of container.students" :key="student.studentId">
            <td>{{student.studentId}}</td>
            <td>{{student.studentFirstName}}</td>
            <td colspan="2">{{student.studentLastName}}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import { classDetailsAsync } from "../../api/classApi";
export default {
  data() {
    return {
      container: {}
    };
  },
  mounted() {
    this.refreshClass(this.$route.params.id);
  },
  methods: {
    async refreshClass(classId) {
      try {
        this.container = await classDetailsAsync(classId);
      } catch (e) {
        console.error(e);
      }
    }
  }
};
</script>
