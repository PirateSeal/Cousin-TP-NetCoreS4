<template>
  <div>
    <div class="mb-4 d-flex justify-content-between">
      <h1>Gestion des élèves</h1>
      <div class="d-flex bd-highlight">
        <div class="p-2 flex-fill bd-highlight">
          Page number :
          <input class="page" type="number" v-model="page">
        </div>
        <div class="p-2 flex-fill bd-highlight">
          <input type="text" name="SearchBox" v-model="search" placeholder="Search student">
        </div>
        <div class="p-2 flex-fill bd-highlight">
          <router-link class="btn btn-primary" :to="`students/create`">
            <i class="fa fa-plus"></i> Ajouter un élève
          </router-link>
        </div>
      </div>
    </div>

    <table class="table table-striped table-hover table-bordered">
      <thead>
        <tr align="center">
          <th>ID</th>
          <th>Nom</th>
          <th>Prénom</th>
          <th>Date de naissance</th>
          <th>Login github</th>
          <th>Options</th>
        </tr>
      </thead>

      <tbody>
        <tr v-if="studentList.length == 0">
          <td colspan="6" class="text-center">Il n'y a actuellement aucun élève.</td>
        </tr>

        <tr v-for="i of searchList " :key="i.studentId" align="center">
          <td>{{ i.studentId }}</td>
          <td>{{ i.lastName }}</td>
          <td>{{ i.firstName }}</td>
          <td>{{ new Date(i.birthDate).toLocaleDateString() }}</td>
          <td>{{ i.gitHubLogin }}</td>
          <td>
            <router-link :to="`students/edit/${i.studentId}`">
              <i class="fa fa-pencil"></i>
            </router-link>
            <a href="#" @click="deleteStudent(i.studentId)">
              <i class="fa fa-trash"></i>
            </a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import {
  getStudentListAsync,
  deleteStudentAsync,
  insertStudents
} from "../../api/studentApi";

export default {
  data() {
    return {
      studentList: [],
      page: 0,
      elPerPage: 5,
      search: ""
    };
  },

  async mounted() {
    await this.refreshList();
  },

  computed: {
    searchList: function() {
      if (this.search !== "") {
        return this.filteredStudents;
      } else {
        return this.studentList.slice(
          this.page * this.elPerPage,
          this.page * this.elPerPage + this.elPerPage
        );
      }
    },
    filteredStudents: function() {
      return this.studentList.filter(student => {
        return student.lastName.match(this.search);
      });
    }
  },

  methods: {
    async refreshList() {
      try {
        this.studentList = await getStudentListAsync();
      } catch (e) {
        console.error(e);
      }
    },

    async deleteStudent(studentId) {
      try {
        await deleteStudentAsync(studentId);
        await this.refreshList();
      } catch (e) {
        console.error(e);
      }
    }
  }
};
</script>