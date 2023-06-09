<template>
  <v-dialog v-model="lectorqr">
    <v-container class="d-flex justify-center" width="100%">
      <v-card width="500" color="teal" theme="dark">
        <v-card-title>
          <div class="text-h5 text-center font-weight-light">Leer QR</div>
        </v-card-title>
        <v-card-text>
          <v-cloak @drop.prevent="addDropFile" @dragover.prevent>
            <div class="drop-area">
              <v-img :src="imageURL" />
            </div>
            <v-file-input
              accept="image/*"
              capture="user"
              label="File input"
              v-model="imageqr"
              @change="onFileChange"
              variant="filled"
              prepend-icon="mdi-camera"
            >
            </v-file-input>
          </v-cloak>
        </v-card-text>

        <v-divider></v-divider>
        <v-card-actions>
          <v-row>
            <v-col cols="6" class="d-flex justify-center align-center">
              <v-btn
                class="bg-success"
                min-width="92"
                rounded
                variant="outlined"
                @click="decodeImg"
              >
                Scan
              </v-btn>
            </v-col>
            <v-col cols="6" class="d-flex justify-center align-center">
              <v-btn
                class="bg-secondary"
                min-width="92"
                rounded
                variant="outlined"
                @click="lectorqr = false"
              >
                Close
              </v-btn>
            </v-col>
          </v-row>
        </v-card-actions>
      </v-card>
    </v-container>
  </v-dialog>
</template>

<script setup lang="ts">
import { useAppStore } from "@/store/appStore";
import { storeToRefs } from "pinia";
import { ref } from "vue";
import QrcodeDecoder from "qrcode-decoder";

const appstore = useAppStore();

const { imageqr } = storeToRefs(appstore);

const { lectorqr } = storeToRefs(appstore);

const imageURL = ref("");

//************************ */

const decodeImg = () => {
  const qr = new QrcodeDecoder();

  const img = imageURL.value;

  qr.decodeFromImage(img).then((res) => {
    console.dir(res);
  });
};

//************************** */

const onFileChange = () => {
  const file = imageqr.value[0];
  if (file) {
    imageURL.value = URL.createObjectURL(file);
  }
};

//****************************** */

const addDropFile = () => {
  const file = imageqr.value[0];
  if (file) {
    imageURL.value = URL.createObjectURL(file);
  }
};

//****************************** */
</script>

<style scoped lang="scss">
.drop-area {
  height: 300px;
  color: #fff;
  text-align: center;
  font-weight: bold;
  padding: 10px;
  background-color: rgba(0, 0, 0);
  opacity: 0.8;
}

.drop-area:hover {
  opacity: 0.5;
  cursor: pointer;
}

.drop-error {
  color: red;
  font-weight: bold;
}
</style>
