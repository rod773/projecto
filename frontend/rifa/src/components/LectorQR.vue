<template>
  <v-dialog v-model="lectorqr">
    <v-container class="d-flex justify-center" width="100%">
      <v-card width="500" color="teal" theme="dark">
        <v-card-title>
          <div class="text-h5 text-center font-weight-light">
            Carga Imagen QR
          </div>
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-col>
              <div class="drop-area">
                <v-img :src="imageURL" />
              </div>
              <v-file-input
                selected=""
                accept="image/*"
                capture="user"
                label="Imagen QR"
                v-model="imageqr"
                @change="onFileChange"
                variant="filled"
                prepend-icon="mdi-camera"
                clearable
              >
              </v-file-input>
            </v-col>
            <v-col cols="12" class="text-center text-h3"
              >{{ QRdecoded }}
            </v-col>
            <v-dialog v-model="showPremios">
              <v-container
                class="d-flex justify-center align-center"
                width="100%"
              >
                <v-row>
                  <v-col class="d-flex justify-center" cols="12">
                    <v-card
                      class="d-flex justify-center align-center"
                      height="100"
                      width="300"
                      color="teal"
                      theme="dark"
                    >
                      <router-link to="premios" class="mx-5">
                        <span class="text-h4" @click="onClose">premios</span>
                      </router-link>
                      <v-btn
                        x-small
                        icon
                        class="bg-indigo"
                        @click="showPremios = false"
                      >
                        <v-icon>mdi-close</v-icon>
                      </v-btn>
                    </v-card>
                  </v-col>
                </v-row>
              </v-container>
            </v-dialog>
          </v-row>
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
                Scanear
              </v-btn>
            </v-col>
            <v-col cols="6" class="d-flex justify-center align-center">
              <v-btn
                class="bg-secondary"
                min-width="92"
                rounded
                variant="outlined"
                @click="onClose"
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

//************************* */

const imageURL = ref("");

const QRdecoded = ref("");

const showPremios = ref(false);

//************************* */

const decodeImg = () => {
  const qr = new QrcodeDecoder();

  const img = imageURL.value;

  qr.decodeFromImage(img).then((res) => {
    console.dir(res.data);
    if (res.data) {
      QRdecoded.value = res.data;
      showPremios.value = true;
    } else {
      QRdecoded.value = "No es QR";
      showPremios.value = false;
    }
  });
};

//************************** */

const onFileChange = () => {
  const file = imageqr.value[0];
  if (file) {
    imageURL.value = URL.createObjectURL(file);
    URL.revokeObjectURL(file);
  }
};

//****************************** */

const addDropFile = () => {
  const file = imageqr.value[0];
  if (file) {
    imageURL.value = URL.createObjectURL(file);
    URL.revokeObjectURL(file);
  }
};

//****************************** */

const onClose = () => {
  lectorqr.value = false;
  imageqr.value = null;
  imageURL.value = "";
  QRdecoded.value = "";
  showPremios.value = false;
};
//****************************** */
</script>

<style scoped lang="scss">
.drop-area {
  margin: 0 auto;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 300px;
  width: 300px;
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
</style>
