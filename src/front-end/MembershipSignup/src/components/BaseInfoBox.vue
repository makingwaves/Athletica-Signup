<template>
    <div class="box">
        <p>{{ label }}</p>
    </div>
</template>

<script>

export default {
    name: 'BaseInfoBox',
    props: [
        'label'
    ],
    components: {
        
    }
}
</script>

<style>
.box {
    padding: 10px;
    background: #D3FBE0;
    border-radius: 5px;
    display: inline-block;
}
</style>